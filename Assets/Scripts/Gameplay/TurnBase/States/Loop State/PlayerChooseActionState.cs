using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.State
{
    public class PlayerChooseActionState : BaseLoopState
    {
        private IReadOnlyList<BasePlayerUnit> _players;
        private IReadOnlyList<BaseEnemyUnit> _enemys;

        public PlayerChooseActionState(IReadOnlyList<BasePlayerUnit> players, IReadOnlyList<BaseEnemyUnit> enemys)
        {
            _players = players;
            _enemys = enemys;
        }

        public override string StateId => "chooseAction";

        protected override UniTask PreState()
        {
            return UniTask.Delay(500);
        }
        protected override UniTask PostState()
        {
            return UniTask.Delay(500);
        }
        protected override UniTask ProcessState()
        {
            Debug.Log($"Its {StateId} state");
            
            for (int i = 0; i < _players.Count; i++)
            {
                SetUnitAction(_players[i]);
            }
            for (int i = 0; i < _enemys.Count; i++)
            {
                SetUnitAction(_enemys[i]);
            }
            return UniTask.Delay(500);
        }

        private void SetUnitAction(CombatUnitControl unit)
        {
            unit.Data.SetAction(unit.Data.AttackAction);

        }
    }
}
