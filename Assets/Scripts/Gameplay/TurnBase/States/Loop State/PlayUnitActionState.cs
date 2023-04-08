using CombTeen.Gameplay.Screen.ActionPanel;
using CombTeen.Gameplay.Unit.Action;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.State
{
    public class PlayUnitActionState : MultiLoopStateProcessor<BaseUnitAction>
    {
        private IActionPanelControl _actionPanel;
        public PlayUnitActionState(CalculateActionOrderState calculatorOrder, IActionPanelControl actionPanel)
        {
            CalculatorOrder = calculatorOrder;
            _actionPanel = actionPanel;
        }

        public override string StateId => "playUnitAction";

        protected override async UniTask PreState()
        {
            _actionPanel.EnableControl(false);
            UILogger.Instance.LogMain($"Its Pre-{StateId} state");
            await UniTask.Delay(500);
        }

        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }
    }
}
