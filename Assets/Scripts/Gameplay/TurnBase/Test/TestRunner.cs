using System.Collections.Generic;
using System.Linq;
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

    private void Start() {
        Run();
    }

    [Inject]
    public void Inject(ITileController tileControl)
    {
        _tileControl = tileControl;
    }

    private IReadOnlyList<BasePlayerUnit> _playerUnits;
    private IReadOnlyList<BaseEnemyUnit> _enemyUnits;

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
    }
    private void Initial()
    {
        var unit = BridgeData.Instance.GetCurrentUnitData();

        for (int i = 0; i < _playerUnits.Count; i++)
        {
            _playerUnits[i].InitialUnitData(unit.Players.ElementAt(i));
            _playerUnits[i].SetLocation(_tileControl.Test_GetRandomTile());

        }
        for (int i = 0; i < _enemyUnits.Count; i++)
        {
            _enemyUnits[i].InitialUnitData(unit.Enemys.ElementAt(i));
            _enemyUnits[i].SetLocation(_tileControl.Test_GetRandomTile());
        }
    }



    [Button]
    private void Run()
    {
        Initial();
        _runner.RunAsync().Forget();
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
}
