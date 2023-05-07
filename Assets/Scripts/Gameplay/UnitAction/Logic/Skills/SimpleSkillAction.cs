using System.Linq;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    // [CreateAssetMenu(menuName = "Test/Simple Unit State")]
    public class SimpleSkillAction : BaseSkillAction
    {
        public override string ActionId => "A-SKL-000";
        public override ITileArea ActionArea => new TileArea
        {
            Up = 2,
            Down = 2,
            Left = 2,
            Right = 2,

            DownLeft = 2,
            DownRight = 2,
            UpLeft = 2,
            UpRight = 2
        };
        protected override UniTask PreState()
        {
            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            TargetUnits.ElementAt(0).UnitStatusData.ChangeCombatStatusAction.TakeDamage(20);
            return UniTask.Delay(500);
        }

        public override void SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            targetChooseHelper.OnSelectTargets.RemoveAllListeners();
            targetChooseHelper.OnSelectTargets.AddListener(
            (targets) =>
            {
                TargetUnits = targets;
            });
            targetChooseHelper.GetSingleTargetOpponent(Owner);

        }
    }
}
