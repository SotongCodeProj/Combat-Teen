using System.Collections.Generic;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit;
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
        private CombatUnitsHandler _unitsHandler;
        private ITileController _tileControl;

        private bool _isChooseDone = false;
        public ActionPanelController(IActionPanelView view,
                                     CombatUnitsHandler combatUnitHandler,
                                     ITileController tileController
                                    )
        {
            _view = view;
            _unitsHandler = combatUnitHandler;
            _tileControl = tileController;
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
            _currentUnit.UnitActionData.SetAttackAction()
            .SetUnitTargets(_unitsHandler.GetRandomOpenent(_currentUnit));

            _tileControl.ShowTileArea(
                _currentUnit.UnitTileData.Coordinate,
                _currentUnit.UnitActionData.UsedAction.ActionArea,
                out IEnumerable<CombatUnitControl> unitsOnTile
            );
            foreach (var item in unitsOnTile)
            {
                Debug.Log($"Unit On aroundArea : {item.viewName}");
            }
            _isChooseDone = true;
        }
        private void SetDefenseAction()
        {
            _currentUnit.UnitActionData.SetDefeseAction();

            _tileControl.ShowTileArea(
               _currentUnit.UnitTileData.Coordinate,
               _currentUnit.UnitActionData.UsedAction.ActionArea,
               out IEnumerable<CombatUnitControl> unitsOnTile
           );

            foreach (var item in unitsOnTile)
            {
                Debug.Log("Unit On aroundArea : {item.viewName}");
            }
            _isChooseDone = true;
        }
        private void SetSupportAction()
        {
            _currentUnit.UnitActionData.SeSupportAction();

            _tileControl.ShowTileArea(
               _currentUnit.UnitTileData.Coordinate,
               _currentUnit.UnitActionData.UsedAction.ActionArea,
               out IEnumerable<CombatUnitControl> unitsOnTile
           );
            foreach (var item in unitsOnTile)
            {
                Debug.Log("Unit On aroundArea : {item.viewName}");
            }
            _isChooseDone = true;
        }

        private void SetSkillAction(int indexSlot)
        {
            _currentUnit.UnitActionData.SetSkillAction(indexSlot)
            .SetUnitTargets(_unitsHandler.GetRandomOpenent(_currentUnit));

            _tileControl.ShowTileArea(
               _currentUnit.UnitTileData.Coordinate,
               _currentUnit.UnitActionData.UsedAction.ActionArea,
               out IEnumerable<CombatUnitControl> unitsOnTile
           );
            foreach (var item in unitsOnTile)
            {
                Debug.Log("Unit On aroundArea : {item.viewName}");
            }
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

    }
}