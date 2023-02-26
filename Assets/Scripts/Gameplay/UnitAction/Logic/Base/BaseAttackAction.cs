
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public abstract class BaseAttackAction : BaseUnitAction 
    {
        public abstract BaseAttackAction  InitializeOwner(CombatUnitControl owner);
    }
}
