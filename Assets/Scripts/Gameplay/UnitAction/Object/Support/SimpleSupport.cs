
using CombTeen.Gameplay.Unit.Action.Logic;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleSupport : ActionObject<BaseSupportAction>
    {
        public override BaseSupportAction Logic => new SimpleSupportAction();
    }
}
