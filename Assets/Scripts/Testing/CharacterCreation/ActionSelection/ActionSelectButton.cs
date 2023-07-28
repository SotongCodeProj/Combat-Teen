using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UnityEngine.Events;
using CombTeen.Constant;

namespace CombTeen.Testing.CharacterCreation
{
    //TODO : Split into View and Controller
    public class ActionSelectButton : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;
        [SerializeField] private TextMeshProUGUI _nameText;

        private string _currentActionId;
        private ActionType _currentActionType;

        public UnityEvent<string, ActionType> OnClickEvent { private set; get; } = new();

        private void Awake()
        {
            _clickButton.onClick.AddListener(() => OnClickEvent?.Invoke(_currentActionId, _currentActionType));
        }

        public void SetButton(string actionId, string actionName, ActionType actionType)
        {
            _currentActionId = actionId;
            _currentActionType = actionType;
            _nameText.text = actionName;
        }
    }
}
