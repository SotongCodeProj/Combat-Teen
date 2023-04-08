using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace CombTeen.Gameplay.Screen.ActionPanel
{
    public interface IActionPanelControl
    {
        public void InitUnitHandledUnit(CombatUnitControl selectedUnit);
        public bool IsChooseDone();

        public void EnableControl(bool enable);
    }
    public class ActionPanelController : IActionPanelControl, IStartable
    {
        private IActionPanelView _view;
        private CombatUnitControl _currentUnit;
        private CombatUnitsHandler _unitsHandler;
        private ITileController _tileControl;
        private TargetChooseHelper _targetChooseHelper;

        private bool _isChooseDone = false;
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

            _view.AttackClickEvent.AddListener(() => SetAttackActionAsync().Forget());
            _view.DefenseClickEvent.AddListener(() => SetDefenseActionAsycn().Forget());
            _view.SupportClickEvent.AddListener(() => SetSupportActionAsync().Forget());
            _view.SkillClickEvent.AddListener((slotIndex) => SetSkillActionAsync(slotIndex).Forget());
            _view.MoveClickEvent.AddListener(() => SetMoveActionAsync().Forget());
        }

        private async UniTaskVoid SetAttackActionAsync()
        {
            Debug.Log("Choose Attack");
            await _currentUnit.UnitActionData.SetAttackAction()
             .SetUnitTargets(_targetChooseHelper);

            _tileControl.ClearShowTile();
            _isChooseDone = true;
        }
        private async UniTaskVoid SetDefenseActionAsycn()
        {
            await _currentUnit.UnitActionData.SetDefeseAction()
            .SetUnitTargets(_targetChooseHelper);
            _tileControl.ClearShowTile();
            _isChooseDone = true;
        }
        private async UniTaskVoid SetSupportActionAsync()
        {
            await _currentUnit.UnitActionData.SetSupportAction()
            .SetUnitTargets(_targetChooseHelper);

            _tileControl.ClearShowTile();
            _isChooseDone = true;
        }

        private async UniTaskVoid SetSkillActionAsync(int indexSlot)
        {
            await _currentUnit.UnitActionData.SetSkillAction(indexSlot)
            .SetUnitTargets(_targetChooseHelper);

            _tileControl.ClearShowTile();
            _isChooseDone = true;
        }
        private async UniTaskVoid SetMoveActionAsync()
        {
            await _currentUnit.UnitActionData.SetMoveAction()
            .SetUnitTargets(_targetChooseHelper);

            _tileControl.ClearShowTile();
            _isChooseDone = true;
        }

        public void InitUnitHandledUnit(CombatUnitControl selectedUnit)
        {
            _currentUnit = selectedUnit;
            _view.SetVisual(selectedUnit.UnitBasicInfoData.UnitName);
            _isChooseDone = false;
        }

        public bool IsChooseDone()
        {
            return _isChooseDone;
        }

        public void EnableControl(bool enable)
        {
            _view.SetControlEnable(enable);
        }
    }
}