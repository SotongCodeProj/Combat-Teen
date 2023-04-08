using CombTeen.Gameplay.Screen.ActionPanel;
using CombTeen.Gameplay.StateRunner;
using CombTeen.Gameplay.Unit;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace CombTeen.Gameplay.State
{
    public class CheckBattleStatusState : BaseLoopState
    {
        public override string StateId => "checkBattleStatus";

        public UnityEvent OnBattleDone { get; private set; } = new UnityEvent();

        private IActionPanelControl _actionPanel;
        private CombatUnitsHandler _unitHandler;
        public CheckBattleStatusState(CombatUnitsHandler combatUnitsHandler, IActionPanelControl actionPanel)
        {
            _unitHandler = combatUnitsHandler;
            _actionPanel = actionPanel;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask PreState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            var enemyUnits = _unitHandler.GetEnemyUnits();
            var playerUnits = _unitHandler.GetPlayerUnits();
            bool isDone = true;

            foreach (var enemy in enemyUnits)
            {
                if (enemy.UnitStatusData.CombatStat.Health >= 0)
                {
                    isDone = false;
                    break;
                }
                Debug.LogWarning("You Win");
            }
            foreach (var player in playerUnits)
            {
                if (player.UnitStatusData.CombatStat.Health >= 0)
                {
                    isDone = false;
                    break;
                }
                Debug.LogWarning("You Lose");
            }

            if (isDone)
            {
                _actionPanel.EnableControl(false);
                OnBattleDone?.Invoke();
            }
            return UniTask.Delay(500);
        }
    }
}