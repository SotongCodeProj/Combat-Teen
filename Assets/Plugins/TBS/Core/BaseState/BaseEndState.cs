using System.Threading.Tasks;
using Cysharp.Threading.Tasks;


namespace TBS.Core.State
{
    public abstract class BaseEndState : IEndState
    {
        public abstract string StateId { get; }

        public UniTask PreState => PreProcess();
        public UniTask ProcessSate => MainProcess();
        public UniTask PostState => PostProcess();

        protected abstract UniTask PostProcess();
        protected abstract UniTask PreProcess();
        protected abstract UniTask MainProcess();

        public abstract ValueTask DisposeAsync();
    }
}
