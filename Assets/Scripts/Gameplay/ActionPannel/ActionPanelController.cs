using System.Threading;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using VContainer.Unity;

namespace CombTeen.Gameplay.Screen.ActionPanel
{
    public interface IActionPanelControl
    {
        public void EnableControl(bool enable);
        UniTask<BaseUnitAction> GetUnitActionAsync(CombatUnitControl unit);
    }
    public class ActionPanelController : IActionPanelControl, IStartable
    {
        private IActionPanelView _view;
        private CombatUnitControl _currentUnit;
        private CombatUnitsHandler _unitsHandler;
        private ITileController _tileControl;
        private TargetChooseHelper _targetChooseHelper;
        private UnityEvent<BaseUnitAction> _selectedAction = new UnityEvent<BaseUnitAction>();
        private System.Action _lastChooseAction;

        public ActionPanelController(IActionPanelView view,
                                     CombatUnitsHandler combatUnitHandler,
                                     ITileController tileController,
                                     TargetChooseHelper targetChooseHelper
                                    )
        {
            _view = view;
            _unitsHandler = combatUnitHandler;
            _tileControl = tileController;
            _targetChooseHelper = targetChooseHelper;
        }
        public void Start()
        {
            InitViewEvent();
        }

        private void InitViewEvent()
        {
            _view.AttackClickEvent.AddListener(SetAttackAction);
            _view.DefenseClickEvent.AddListener(SetDefenseAction);
            _view.SupportClickEvent.AddListener(SetSupportAction);
            _view.SkillClickEvent.AddListener(SetSkillAction);
            _view.MoveClickEvent.AddListener(SetMoveAction);
            _view.RotateUnitEvent.AddListener(RotateUnit);


            _view.AttackClickEvent.AddListener(() => _lastChooseAction = SetAttackAction);
            _view.DefenseClickEvent.AddListener(() => _lastChooseAction = SetDefenseAction);
            _view.SupportClickEvent.AddListener(() => _lastChooseAction = SetSupportAction);
            _view.SkillClickEvent.AddListener((index) => { _lastChooseAction = () => SetSkillAction(index); });
            _view.MoveClickEvent.AddListener(() => _lastChooseAction = SetMoveAction);
        }

        private void SetAttackAction()
        {
            Debug.Log($"Choose Attack : {_currentUnit.UnitBasicInfoData.UnitName}");
            _currentUnit.UnitActionData.SetAttackAction()
            .SetUnitTargets(_targetChooseHelper);

        }
        private void SetDefenseAction()
        {
            Debug.Log($"Choose Defense : {_currentUnit.UnitBasicInfoData.UnitName}");

            _currentUnit.UnitActionData.SetDefeseAction()
            .SetUnitTargets(_targetChooseHelper);
        }
        private void SetSupportAction()
        {
            Debug.Log($"Choose Support : {_currentUnit.UnitBasicInfoData.UnitName}");
            _currentUnit.UnitActionData.SetSupportAction()
            .SetUnitTargets(_targetChooseHelper);
        }
        private void SetSkillAction(int indexSlot)
        {
            Debug.Log($"Choose Skill : {_currentUnit.UnitBasicInfoData.UnitName}");
            _currentUnit.UnitActionData.SetSkillAction(indexSlot)
            .SetUnitTargets(_targetChooseHelper);
        }
        private void SetMoveAction()
        {
            Debug.Log($"Choose Move : {_currentUnit.UnitBasicInfoData.UnitName}");
            _currentUnit.UnitActionData.SetMoveAction()
            .SetUnitTargets(_targetChooseHelper);
        }

        private void RotateUnit()
        {
            _currentUnit.SetFacing(!_currentUnit.IsFacingLeft);
            _lastChooseAction?.Invoke();
        }
        public async UniTask<BaseUnitAction> GetUnitActionAsync(CombatUnitControl unit)
        {
            var cts = new CancellationTokenSource();
            _view.SetControlEnable(true);

            _currentUnit = unit;
            _view.SetVisual(unit.UnitBasicInfoData.UnitName);

            await _targetChooseHelper.OnClickEvent.OnInvokeAsync(cts.Token);

            _tileControl.ClearShowTile();
            _view.SetControlEnable(false);
            cts.Dispose();
            _lastChooseAction = null;
            return _currentUnit.UnitActionData.UsedAction;
        }
        public void EnableControl(bool enable)
        {
            _view.SetControlEnable(enable);
        }
    }
}