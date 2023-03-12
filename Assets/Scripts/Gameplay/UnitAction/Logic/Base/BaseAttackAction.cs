
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseAttackAction : BaseUnitAction
    {
        protected CombatUnitControl TargetUnits { private set;  get; }

        public abstract BaseAttackAction InitializeOwner(CombatUnitControl owner);

        public virtual void SetUnitTargets(CombatUnitControl targets)
        {
            TargetUnits = targets;
        }
    }
}
