using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitActionModel
    {
        public CombatUnitControl TargetedUnits { private set; get; }

        public void SetActionTarget(CombatUnitControl target)
        {
            TargetedUnits = target;
        }
    }
}
