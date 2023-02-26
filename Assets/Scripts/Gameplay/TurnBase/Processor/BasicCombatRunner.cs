using System.Linq;
using CombTeen.Gameplay.StateModel;
using Cysharp.Threading.Tasks;
using TBS.Core;
using TBS.Core.Runner;
using UnityEngine;

namespace CombTeen.Gameplay.StateRunner
{
    public class BasicCombatRunner : IStateProcessor<BasicCombatModel>
    {
        public TBS_State _currentState { private set; get; }
        public int LoopIndex { private set; get; } = 0;
        public BasicCombatModel Data { protected set; get; }
        public bool _doneLoopState { private set; get; } = false;

        public BasicCombatRunner(BasicCombatModel data)
        {
            Data = data;
        }

        public void Next()
        {
            if (!_currentState.Equals(TBS_State.Loop) || !_doneLoopState) { Debug.LogWarning("Error whenNext"); return; }
            LoopIndex = (LoopIndex + 1) >= Data.LoopStates.Count() ?
                            0 : LoopIndex + 1;

        }
        public async UniTask BeginProcess()

        {
            LoopIndex = 0;
            _currentState = TBS_State.Start;

            await using (IStartState start = Data.StartState)
            {
                await start.PreState;
                await start.ProcessSate;
                await start.PostState;
            }
        }
        public async UniTask LoopProcess()
        {
            _doneLoopState = false;
            _currentState = TBS_State.Loop;
            var targetState = Data.LoopStates.ElementAt(LoopIndex);

            await using (ILoopState target = targetState)
            {
                await target.PreState;
                await target.ProcessSate;
                await target.PostState;
            }
            _doneLoopState = true;
        }
        public async UniTask EndProcess()
        {
            if (!_currentState.Equals(TBS_State.Loop)) return;

            _currentState = TBS_State.End;
            await using (IEndState endState = Data.EndState)
            {
                await endState.PreState;
                await endState.ProcessSate;
                await endState.PostState;
            }
        }
    }
}
