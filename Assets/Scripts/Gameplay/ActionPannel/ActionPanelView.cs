using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CombTeen.Gameplay.Screen.ActionPanel
{
    public interface IActionPanelView
    {
        public UnityEvent AttackClickEvent { get; }
        public UnityEvent DefenseClickEvent { get; }
        public UnityEvent SupportClickEvent { get; }
        public UnityEvent<int> SkillClickEvent { get; }
        public UnityEvent MoveClickEvent { get; }
        public UnityEvent RotateUnitEvent { get; }

        void SetControlEnable(bool enable);
        public void SetVisual(string ownerName);

    }
    public class ActionPanelView : MonoBehaviour, IActionPanelView
    {
        public UnityEvent AttackClickEvent { private set; get; } = new UnityEvent();
        public UnityEvent DefenseClickEvent { private set; get; } = new UnityEvent();
        public UnityEvent SupportClickEvent { private set; get; } = new UnityEvent();
        public UnityEvent<int> SkillClickEvent { private set; get; } = new UnityEvent<int>();
        public UnityEvent MoveClickEvent { get; } = new UnityEvent();
        public UnityEvent RotateUnitEvent { get; } = new UnityEvent();

        [Header("HUD Component")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _defenseButton;
        [SerializeField] private Button _supportButton;
        [SerializeField] private Button[] _skillButtons;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _rotateButton;

        [Header("Visual Information")]
        [SerializeField] private TextMeshProUGUI _ownerName;

        [Header("Other")]
        //TODO : Need better way to Handler this Raycaster or change the logic
        [SerializeField] private PhysicsRaycaster _objectRaycaster;
        public PhysicsRaycaster ObjectRaycaster => _objectRaycaster;
        private void Awake()
        {
            InitButtonEvent();
        }
        private void InitButtonEvent()
        {
            _attackButton.onClick.AddListener(() => AttackClickEvent?.Invoke());
            _defenseButton.onClick.AddListener(() => DefenseClickEvent?.Invoke());
            _supportButton.onClick.AddListener(() => SupportClickEvent?.Invoke());
            _moveButton.onClick.AddListener(() => MoveClickEvent?.Invoke());
            _rotateButton.onClick.AddListener(() => RotateUnitEvent?.Invoke());
            for (int i = 0; i < _skillButtons.Length; i++)
            {
                int index = i;
                _skillButtons[i].onClick.AddListener(() => SkillClickEvent?.Invoke(index));
            }
        }

        public void SetVisual(string ownerName)
        {
            _ownerName.text = ownerName;
        }

        public void SetControlEnable(bool enable)
        {
            _canvasGroup.alpha = enable ? 1 : 0;
            _canvasGroup.interactable = enable;
            _canvasGroup.blocksRaycasts = enable;
        }
    }
}
