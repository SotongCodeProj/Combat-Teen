using CombTeen.Gameplay.Unit.Action;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.State
{
    public class PlayUnitActionState : MultiLoopStateProcessor<BaseUnitAction>
    {
        public PlayUnitActionState(CalculateActionOrderState calculatorOrder)
        {
            CalculatorOrder = calculatorOrder;
        }

        public override string StateId => "playUnitAction";

        protected override async UniTask PreState()
        {
            UILogger.Instance.LogMain($"Its Pre-{StateId} state");
            await UniTask.Delay(500);
        }

        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }
    }
}
