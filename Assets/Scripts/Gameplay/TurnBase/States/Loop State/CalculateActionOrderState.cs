using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit;
using Cysharp.Threading.Tasks;
using UnityEngine;

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
            // _testUnitState.Clear();
            return UniTask.Delay(500);
        }

        protected override UniTask PreState()
        {
            CalculateOrder();
            return UniTask.Delay(500);
        }

        protected override UniTask ProcessState()
        {
            Debug.Log($"Its {StateId} state");
            return UniTask.Delay(500);
        }

        public BaseUnitAction[] GetOrder()
        {
            return _actionOrderResult.ToArray();
        }

        private void CalculateOrder()
        {
            var players = _unitHandler.GetPlayerUnits();
            var enemys = _unitHandler.GetEnemyUnits();

            _actionOrderResult.Clear();

            int indexData = 0;
            for (int i = 0; i < players.Length + enemys.Length; i++)
            {
                bool odd = i % 2 == 0;
                _actionOrderResult.Add(odd ?
                players[indexData].Data.UsedAction :
                enemys[indexData].Data.UsedAction);

                if (!odd) indexData++;
            }
        }

    }
}
