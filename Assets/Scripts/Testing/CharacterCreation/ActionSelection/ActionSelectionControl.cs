using System.Collections.Generic;
using CombTeen.Constant;
using UnityEngine;


namespace CombTeen.Testing.CharacterCreation
{
    public class ActionSelectionControl : MonoBehaviour
    {
        [SerializeField] private ActionSelectionView _view;
        [SerializeField] private ActionSelectButton[] _actionSelectButtons;

        public string SelectedAttackId;
        public string SelectedDefenseId;
        public string SelectedSkillId;
        public string SelectedSupportId;
        public string SelectedMoveId;

        private void Awake()
        {
            _view.ShowAvailableActionEvent.AddListener(LoadAction);

            foreach (var item in _actionSelectButtons)
            {
                item.OnClickEvent.AddListener(SetSelectAction);
            }
        }

        private void LoadAction(ActionType actionType)
        {
            Debug.Log("Call Load Action");
            var actions = TempActionDataLoader.Instance.GetDatas(actionType);
            for (int i = 0; i < _actionSelectButtons.Length; i++)
            {
                if (i >= actions.Length)
                {
                    _actionSelectButtons[i].gameObject.SetActive(false);
                    continue;
                }
                _actionSelectButtons[i].gameObject.SetActive(true);
                _actionSelectButtons[i].SetButton(actions[i].ActionId, actions[i].ActionName, actions[i].ActionType);
            }
        }

        private void SetSelectAction(string actionId, ActionType actionType)
        {
            Debug.Log($"Action Set : {actionId}");
            switch (actionType)
            {
                case ActionType.Attack:
                    SelectedAttackId = actionId;
                    break;

                case ActionType.Defense:
                    SelectedDefenseId = actionId;
                    break;

                case ActionType.Skill:
                    SelectedSkillId = actionId;
                    break;

                case ActionType.Support:
                    SelectedSupportId = actionId;
                    break;

                case ActionType.Move:
                    SelectedMoveId = actionId;
                    break;
            }
        }
    }
}
