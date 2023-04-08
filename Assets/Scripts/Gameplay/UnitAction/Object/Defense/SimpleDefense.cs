using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public class SimpleDefense : ActionObject<BaseDefenseAction>
    {
        public override BaseDefenseAction Logic => new SimpleDefenseAction();
    }
}
