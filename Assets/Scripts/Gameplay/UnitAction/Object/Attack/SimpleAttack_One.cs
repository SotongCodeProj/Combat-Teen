using CombTeen.Gameplay.Unit.Action.Logic;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleAttack_One : ActionObject<BaseAttackAction>
    {
        public override BaseAttackAction Logic => new SimpleAttackAction_One();
    }
}