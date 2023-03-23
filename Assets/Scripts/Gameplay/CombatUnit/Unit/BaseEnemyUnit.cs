using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;

namespace CombTeen.Gameplay.Unit
{
    public interface IEnemyUnit { }
    public class BaseEnemyUnit : CombatUnitControl, IEnemyUnit
    {
        public override string UnitId => "Enemy";

        [Inject]
        public void Inject(ITileController tileController)
        {
            TileControl = tileController;
        }

        public BaseEnemyUnit(CombatUnitView view)
        {
            View = view;
        }
    }
}
