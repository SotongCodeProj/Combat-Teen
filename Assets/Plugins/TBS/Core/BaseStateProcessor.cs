using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TBS.Core.Runner
{
    public enum TBS_State
    {
        Start,
        Loop,
        End
    }
    public abstract class BaseStateProcessor<M> : ScriptableObject, IStateProcessor<M> where M : IStateTurnModel
    {
        public TBS_State _currentState { private set; get; }
        public int LoopIndex { private set; get; } = 0;

        public M Data { protected set; get; }

        public void Next()
        {
            if (!_currentState.Equals(TBS_State.Loop)) return;
            LoopIndex = (LoopIndex + 1) >= Data.LoopStates.Count() ?
                            0 : LoopIndex + 1;
        }
        public UniTask RunAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Terminate()
        {
            throw new System.NotImplementedException();
        }

        private async UniTask BeginProcess()

        {
            LoopIndex = 0;
            _currentState = TBS_State.Start;

            await using (IStartState start = Data.StartState)
            {
                await start.PreState;
                await start.ProcessSate;
                await start.PostState;
            }

            if (_currentState.Equals(TBS_State.Start))
            {
                await LoopProcess();
            }
        }
        private async UniTask LoopProcess()
        {
            _currentState = TBS_State.Loop;
            var targetState = Data.LoopStates.ElementAt(LoopIndex);

            await using (ILoopState target = targetState)
            {
                await target.PreState;
                await target.ProcessSate;
                await target.PostState;
            }
        }
        private async UniTask EndProcess()
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
