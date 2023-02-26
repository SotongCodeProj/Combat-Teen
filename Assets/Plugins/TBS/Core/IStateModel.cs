using System.Collections.Generic;
using TBS.Core.State;

namespace TBS.Core.Runner
{
    public interface IStateTurnModel
    {
        public IStartState StartState { get; }
        public IEnumerable<ILoopState> LoopStates { get; }
        public IEndState EndState { get; }
    }
}
