using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleSkill : SkillObject<BaseSkillAction>
    {
        public override BaseSkillAction Logic => new SimpleSkillAction();
    }
}
