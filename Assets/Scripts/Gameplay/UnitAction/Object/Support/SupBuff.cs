
using CombTeen.Gameplay.Unit.Action.Logic;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SupBuff : ActionObject<BaseSupportAction>
    {
        public override BaseSupportAction Logic => new SupBuffAction();
    }
}
