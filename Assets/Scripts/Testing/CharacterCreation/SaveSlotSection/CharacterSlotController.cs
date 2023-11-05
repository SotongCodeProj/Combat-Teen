using UnityEngine;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterSlotController : MonoBehaviour
    {
        [SerializeField] private CharacterSlotButton[] _slotButtons;

        public int SvaeSlot { private set; get; } = 0;
        private void Awake()
        {
            foreach (var item in _slotButtons)
            {
                item.OnClickEvent.AddListener(SelectSlot);
            }
        }

        private void SelectSlot(int slotIndex)
        {
            SvaeSlot = slotIndex;
        }
    }
}
