using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer.Unity;

namespace CombTeen.Gameplay.Screen.ActionPanel
{
    public interface IActionPanelControl
    {

        public void InitUnitHandledUnit(CombatUnitControl selectedUnit);
        public bool IsChooseDone();
    }
    public class ActionPanelController : IActionPanelControl, IStartable
    {
        private IActionPanelView _view;
        private CombatUnitControl _currentUnit;

        private bool _isChooseDone = false;
        public ActionPanelController(IActionPanelView view)
        {
            _view = view;
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
        }

        private void SetAttackAction()
        {
            _currentUnit.Data.SetAction(_currentUnit.Data.AttackAction);
            _isChooseDone = true;
        }
        private void SetDefenseAction()
        {
            _currentUnit.Data.SetAction(_currentUnit.Data.DefenseAction);
            _isChooseDone = true;
        }
        private void SetSupportAction()
        {
            _currentUnit.Data.SetAction(_currentUnit.Data.SupportAction);
            _isChooseDone = true;
        }

        private void SetSkillAction(int indexSlot)
        {
            _currentUnit.Data.SetAction(_currentUnit.Data.SkillActions[indexSlot]);
            _isChooseDone = true;
        }

        public void InitUnitHandledUnit(CombatUnitControl selectedUnit)
        {
            _currentUnit = selectedUnit;
            _view.SetVisual(selectedUnit.Data.UnitName);
            _isChooseDone = false;
        }

        public bool IsChooseDone()
        {
            return _isChooseDone;
        }

    }
}