using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit;
using Cysharp.Threading.Tasks;
using System.Linq;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.State
{
    // [CreateAssetMenu(menuName = "TB-State/Calculate Action")]
    public class CalculateActionOrderState : BaseLoopState
    {
        private CombatUnitsHandler _unitHandler;
        private List<BaseUnitAction> _actionOrderResult = new List<BaseUnitAction>();

        public CalculateActionOrderState(CombatUnitsHandler combatUnitsHandler)
        {
            _unitHandler = combatUnitsHandler;
        }

        public override string StateId => "calculateAction";

        protected override UniTask PostState()
        {
            return UniTask.Delay(500);
        }

        protected override UniTask PreState()
        {
            CalculateOrder();
            return UniTask.Delay(500);
        }

        protected override UniTask ProcessState()
        {
            UILogger.Instance.LogMain($"Its {StateId} state");
            return UniTask.Delay(500);
        }

        public BaseUnitAction[] GetOrder()
        {
            return _actionOrderResult.ToArray();
        }

        private void CalculateOrder()
        {
            List<CombatUnitControl> actionUnits = new List<CombatUnitControl>(_unitHandler.GetAllUnits());

            _actionOrderResult.Clear();
            for (int i = 0; i < actionUnits.Count(); i++)
            {
                if (actionUnits[i].UnitStatusData.CombatStat.Health <= 0)
                {
                    actionUnits.RemoveAt(i);
                }
            }

            var SortedList = actionUnits.OrderByDescending(unit => unit.UnitStatusData.CombatStat.Speed).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                _actionOrderResult.Add(SortedList[i].UnitActionData.UsedAction);
            }

        }

    }
}
