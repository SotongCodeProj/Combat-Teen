
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseDefenseAction : BaseUnitAction
    {
        public abstract BaseDefenseAction  InitializeOwner(CombatUnitControl owner);
    }
}
