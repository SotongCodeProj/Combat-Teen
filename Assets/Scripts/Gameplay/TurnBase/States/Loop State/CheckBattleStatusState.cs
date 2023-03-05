using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.State
{
    //   [CreateAssetMenu(menuName = "TB-State/Check Battle Status")]
    public class CheckBattleStatusState : BaseLoopState
    {
        public override string StateId => "checkBattleStatus";

        protected override UniTask PostState()
        {
            return UniTask.Delay(500);
        }

        protected override UniTask PreState()
        {
            return UniTask.Delay(500);
        }

        protected override UniTask ProcessState()
        {
            UILogger.Instance.LogMain($"Its {StateId} state");
            return UniTask.Delay(500);
        }
    }
}