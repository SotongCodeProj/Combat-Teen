using Cysharp.Threading.Tasks;


namespace TBS.Core.Runner
{
    public interface IStateProcessor<M> where M : IStateTurnModel
    {
        public int LoopIndex { get; }

        M Data { get; }

        public void Next();
        public UniTask RunAsync();
        public void Terminate();
    }
}
