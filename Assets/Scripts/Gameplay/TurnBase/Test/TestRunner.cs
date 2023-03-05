using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.StateRunner;
using CombTeen.Gameplay.Unit;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using VContainer;

public class TestRunner : MonoBehaviour
{
    [SerializeField] private BasicCombatRunner _runner;
    [SerializeField] private Test_PlayCharacterData _testData;

    private IReadOnlyList<BasePlayerUnit> _playerUnits;
    private IReadOnlyList<BaseEnemyUnit> _enemyUnits;

    private bool _keepRun = true;

    [Inject]
    public void Inject(BasicCombatRunner runner,
                       IReadOnlyList<BasePlayerUnit> playerUnits,
                       IReadOnlyList<BaseEnemyUnit> enemyUnits)
    {
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
        }
        for (int i = 0; i < _enemyUnits.Count; i++)
        {
            _enemyUnits[i].InitialUnitData(_testData.EnemysData[i]);
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
}
