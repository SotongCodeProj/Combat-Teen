using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.MVC;
using CombTeen.Gameplay.Screen.ActionPanel;

namespace CombTeen.Gameplay.State
{
    public class PlayerChooseActionState : BaseLoopState
    {
        private IReadOnlyList<BasePlayerUnit> _players;
        private IReadOnlyList<BaseEnemyUnit> _enemys;
        private IActionPanelControl _actionPanel;

        public PlayerChooseActionState(IReadOnlyList<BasePlayerUnit> players, IReadOnlyList<BaseEnemyUnit> enemys,
        IActionPanelControl actionPanel)
        {
            _players = players;
            _enemys = enemys;
            _actionPanel = actionPanel;
        }

        public override string StateId => "chooseAction";

        protected override UniTask PreState()
        {
            _actionPanel.EnableControl(true);
            return UniTask.Delay(500);
        }
        protected override UniTask PostState()
        {
            return UniTask.Delay(500);
        }
        protected override async UniTask ProcessState()
        {
            UILogger.Instance.LogMain($"Its {StateId} state");

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].UnitStatusData.CombatStat.Health <= 0) continue;
                _actionPanel.InitUnitHandledUnit(_players[i]);
                await UniTask.WaitUntil(_actionPanel.IsChooseDone);
            }
            for (int i = 0; i < _enemys.Count; i++)
            {
                if (_enemys[i].UnitStatusData.CombatStat.Health <= 0) continue;
                _actionPanel.InitUnitHandledUnit(_enemys[i]);
                await UniTask.WaitUntil(_actionPanel.IsChooseDone);
            }
            await UniTask.Delay(500);
        }
    }
}
