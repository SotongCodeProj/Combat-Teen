using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer unitSprite;

        internal void SetFacing(bool facingLeft)
        {
            unitSprite.flipX = !facingLeft;
        }

        internal void SetUnitDie()
        {
            unitSprite.enabled = false;
        }
    }
}
