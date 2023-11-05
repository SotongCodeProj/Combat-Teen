using System;
using CombTeen.Constant;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace CombTeen.Testing.CharacterCreation
{
    public class ActionSelectionView : MonoBehaviour
    {
        public UnityEvent<string> SetSelectedActionEvent { private set; get; } = new();
        public UnityEvent<ActionType> ShowAvailableActionEvent { private set; get; } = new();

        [SerializeField] private Button[] _actionCategoryButtons;
        [SerializeField] private Button[] _actionButtons;

        private void Awake()
        {
            foreach (var button in _actionCategoryButtons)
            {
                button.onClick.AddListener(() => ShowActionByType(Enum.Parse<ActionType>(button.name)));
            }
        }
        
        public void ShowActionByType(ActionType actionType)
        {
            ShowAvailableActionEvent?.Invoke(actionType);
        }

    }
}
