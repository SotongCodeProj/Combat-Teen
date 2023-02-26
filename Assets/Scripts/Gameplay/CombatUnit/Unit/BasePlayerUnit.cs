using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit
{
    public interface IPlayerUnit { }
    public class BasePlayerUnit : CombatUnitControl, IPlayerUnit
    {
        public override string UnitId => "Player";
        public BasePlayerUnit(CombatUnitView view)
        {
            View = view;
        }
    }
}
