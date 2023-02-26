
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseSkillAction :BaseUnitAction
    {
        public abstract BaseSkillAction  InitializeOwner(CombatUnitControl owner);
    }
}
