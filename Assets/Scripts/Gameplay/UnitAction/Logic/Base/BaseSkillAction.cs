
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseSkillAction : BaseUnitAction
    {
        protected CombatUnitControl TargetUnits { private set; get; }
        public abstract BaseSkillAction InitializeOwner(CombatUnitControl owner);

        public virtual void SetUnitTargets(CombatUnitControl targets)
        {
            TargetUnits = targets;
        }
    }
}
