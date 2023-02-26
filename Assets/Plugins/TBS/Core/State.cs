using Cysharp.Threading.Tasks;
using System;

namespace TBS.Core
{
    public interface IState : IAsyncDisposable
    {
        public string StateId { get; }

        public UniTask PreState { get; }
        public UniTask ProcessSate { get; }
        public UniTask PostState { get; }
    }
    public interface IStartState : IState
    {

    }
    public interface ILoopState : IState
    {

    }
    public interface IEndState : IState
    {

    }
}
