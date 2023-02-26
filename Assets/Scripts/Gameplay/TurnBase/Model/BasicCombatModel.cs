using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.State;
using TBS.Core;
using TBS.Core.Runner;
using TBS.Core.StateCollection;
using UnityEngine;

namespace CombTeen.Gameplay.StateModel
{
    // [CreateAssetMenu(menuName = "TB-Model/BasicCombat")]
    public class BasicCombatModel : IStateTurnModel
    {
        [SerializeField] private BasicStartBattleState _startBattle;
        [SerializeField] private List<BaseLoopState> _LoopSequence;
        [SerializeField] private BasicEndBattleState _endBattle;

        public BasicCombatModel(
                                BasicStartBattleState startBattle,

                                PlayerChooseActionState playerChooseAction,
                                CalculateActionOrderState calculateAction,
                                PlayUnitActionState playUnitAction,
                                CheckBattleStatusState checkBattleStatus,

                                BasicEndBattleState endBattle
                                )
        {
            _startBattle = startBattle;
            _endBattle = endBattle;

            _LoopSequence = new List<BaseLoopState>(){
                            playerChooseAction,
                            calculateAction,
                            playUnitAction,
                            checkBattleStatus};
        }

        public IStartState StartState => _startBattle;
        public IEnumerable<ILoopState> LoopStates => _LoopSequence;
        public IEndState EndState => _endBattle;
    }
}
