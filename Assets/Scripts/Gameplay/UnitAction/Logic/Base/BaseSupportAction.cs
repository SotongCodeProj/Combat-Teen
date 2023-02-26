
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseSupportAction : BaseUnitAction
    {
        public abstract BaseSupportAction  InitializeOwner(CombatUnitControl owner);
    }
}
