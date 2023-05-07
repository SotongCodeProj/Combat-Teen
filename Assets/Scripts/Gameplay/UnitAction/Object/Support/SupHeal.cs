
using CombTeen.Gameplay.Unit.Action.Logic;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SupHeal : ActionObject<BaseSupportAction>
    {
        public override BaseSupportAction Logic => new SupHealAction();
    }
}
