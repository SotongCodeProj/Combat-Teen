using System.Collections.Generic;
using TBS.Core;
using TBS.Core.Runner;
using TBS.Core.State;
using TBS.Core.StateCollection;
using UnityEngine;

namespace TBS.Basic
{
    public class TBS_BasicModel : ScriptableObject, IStateTurnModel
    {
        [SerializeField] private StartBattle startBattle;
        [SerializeField] private List<UnitTurn> unitTurnSquences;
        [SerializeField] private EndBattle endBattle;


        public IStartState StartState => startBattle;
        public IEnumerable<ILoopState> LoopStates => unitTurnSquences;
        public IEndState EndState => endBattle;

    }
}
