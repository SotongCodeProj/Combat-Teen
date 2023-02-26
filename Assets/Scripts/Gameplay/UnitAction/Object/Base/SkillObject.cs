using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Object
{
    public abstract class SkillObject<T> : MonoBehaviour where T : BaseUnitAction    {
        public abstract T Logic { get; }
    }
}
