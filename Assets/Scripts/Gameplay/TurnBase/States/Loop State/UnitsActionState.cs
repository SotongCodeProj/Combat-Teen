using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.MVC;
using CombTeen.Gameplay.Screen.ActionPanel;
using System.Linq;

namespace CombTeen.Gameplay.State
{
    public class UnitsActionState : BaseLoopState
    {
        private IActionPanelControl _actionPanel;
        private CombatUnitsHandler _unitsHandler;

        private IEnumerable<CombatUnitControl> _unitsOrder;

        public UnitsActionState(CombatUnitsHandler unitsHandler,
                                      IActionPanelControl actionPanel)
        {
            _unitsHandler = unitsHandler;
            _actionPanel = actionPanel;
        }

        public override string StateId => "chooseAction";

        protected override UniTask PreState()
        {
            var temp = new List<CombatUnitControl>();
            foreach (var unit in _unitsHandler.GetAllUnits())
            {
                if (unit.UnitStatusData.CombatStat.Health <= 0) continue;
                temp.Add(unit);
            }
            _unitsOrder = temp.OrderByDescending(unit => unit.UnitStatusData.CombatStat.Speed);
            _actionPanel.EnableControl(true);

            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }
        protected override async UniTask ProcessState()
        {
            foreach (var unit in _unitsOrder)
            {
                if (unit.UnitStatusData.CombatStat.Health <= 0) continue;
                //Disable Raycast + Enable HUD
                Debug.Log($"Unit Do Action : {unit.UnitBasicInfoData.UnitName}");
                await using (var action = await _actionPanel.GetUnitActionAsync(unit))
                {
                    await action.PreProcess;
                    await action.MainProcess;
                    await action.PostProcess;

                    Debug.Log($"End Action : {unit.UnitBasicInfoData.UnitName} | {action.ActionId}");
                    _actionPanel.EnableControl(false);
                    await UniTask.Delay(500);
                }
            }
        }
    }
}
