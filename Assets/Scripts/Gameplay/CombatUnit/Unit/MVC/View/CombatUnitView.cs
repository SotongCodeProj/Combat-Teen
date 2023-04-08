using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer unitSprite;
        internal void SetUnitDie()
        {
            unitSprite.enabled = false;
        }
    }
}
