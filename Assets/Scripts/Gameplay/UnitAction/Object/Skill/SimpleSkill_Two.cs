using CombTeen.Gameplay.Unit.Action.Logic;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleSkill_Two : ActionObject<BaseSkillAction>
    {
        public override BaseSkillAction Logic => new SimpleSkillAction();
    }
}
