using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleAttack : ActionObject<BaseAttackAction>
    {
        public override BaseAttackAction Logic => new SimpleAttackAction();
    }
}