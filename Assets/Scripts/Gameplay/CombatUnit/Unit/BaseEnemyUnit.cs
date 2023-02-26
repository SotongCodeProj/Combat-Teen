using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit
{
    public interface IEnemyUnit { }
    public class BaseEnemyUnit : CombatUnitControl, IEnemyUnit
    {
        public override string UnitId => "Enemy";
        public BaseEnemyUnit(CombatUnitView view)
        {
            View = view;
        }
    }
}
