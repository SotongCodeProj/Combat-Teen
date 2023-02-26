using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.State
{
    public abstract class MultiLoopStateProcessor<T> : BaseLoopState where T : BaseUnitAction
    {
        protected CalculateActionOrderState CalculatorOrder;

        protected override UniTask ProcessState()
        {
            return RunProcess();
        }

        private async UniTask RunProcess()
        {
            var orders = CalculatorOrder.GetOrder();
            foreach (var item in orders)
            {
                await using (BaseUnitAction running = item)
                {
                    await running.PreProcess;
                    await running.MainProcess;
                    await running.PostProcess;
                }
                await UniTask.Delay(1000);
            }

            await UniTask.Delay(500);
        }
    }
}
