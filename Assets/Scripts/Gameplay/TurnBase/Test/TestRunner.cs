using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.StateRunner;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using VContainer;

public class TestRunner : MonoBehaviour
{
    [SerializeField] private BasicCombatRunner _runner;
    [SerializeField] private Test_PlayCharacterData _testData;

    private ITileController _tileControl;


    [Inject]
    public void Inject(ITileController tileControl)
    {
        _tileControl = tileControl;
    }

    private IReadOnlyList<BasePlayerUnit> _playerUnits;
    private IReadOnlyList<BaseEnemyUnit> _enemyUnits;

    private bool _keepRun = true;

    [Inject]
    public void Inject(BasicCombatRunner runner,
                       IReadOnlyList<BasePlayerUnit> playerUnits,
                       IReadOnlyList<BaseEnemyUnit> enemyUnits,
                       ITileController tileControl)
    {
        _tileControl = tileControl;

        _runner = runner;
        _playerUnits = playerUnits;
        _enemyUnits = enemyUnits;

        Initial();
    }
    private void Initial()
    {
        for (int i = 0; i < _playerUnits.Count; i++)
        {
            _playerUnits[i].InitialUnitData(_testData.PlayersData[i]);
            _playerUnits[i].SetLocation(_tileControl.Test_GetRandomTile());

        }
        for (int i = 0; i < _enemyUnits.Count; i++)
        {
            _enemyUnits[i].InitialUnitData(_testData.EnemysData[i]);
            _enemyUnits[i].SetLocation(_tileControl.Test_GetRandomTile());
        }
    }



    [Button]
    private async void Run()
    {
        _keepRun = true;
        await _runner.BeginProcess();

        while (_keepRun)
        {
            await _runner.LoopProcess();
            await UniTask.WaitUntil(() => _runner._doneLoopState);
            _runner.Next();
        }

        await _runner.EndProcess();
    }

    [Button]
    private void EndCombat()
    {
        _keepRun = false;
    }
    [Button]
    private void RandomCharacterPos()
    {
        for (int i = 0; i < _playerUnits.Count; i++)
        {
            _playerUnits[i].SetLocation(_tileControl.Test_GetRandomTile());

        }
        for (int i = 0; i < _enemyUnits.Count; i++)
        {
            _enemyUnits[i].SetLocation(_tileControl.Test_GetRandomTile());
        }
    }
    [Button]
    private void GetUnitsOnTile()
    {
        foreach (var item in _tileControl.Test_GetAllTile())
        {
            if (item.OccupiedUnit != null)
            {
                Debug.Log($"Tile {item.name} have : {item.OccupiedUnit.viewName}");
            }
        }
    }
}
