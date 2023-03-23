using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;

namespace CombTeen.Gameplay.Unit
{
    public interface IPlayerUnit { }
    public class BasePlayerUnit : CombatUnitControl, IPlayerUnit
    {
        public override string UnitId => "Player";

        [Inject]
        public void Inject(ITileController tileController)
        {
            TileControl = tileController;
        }
        public BasePlayerUnit(CombatUnitView view)
        {
            View = view;
        }
    }
}
