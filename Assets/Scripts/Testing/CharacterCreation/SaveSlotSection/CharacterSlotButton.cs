using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterSlotButton : MonoBehaviour
    {
        [SerializeField] private int _slotIndex;
        [SerializeField] private Button _clickButton;
        public UnityEvent<int> OnClickEvent { private set; get; } = new();

        private void Awake()
        {
            _clickButton.onClick.AddListener(SelectSlot);
        }

        private void SelectSlot()
        {
            OnClickEvent?.Invoke(_slotIndex);
        }
    }
}
