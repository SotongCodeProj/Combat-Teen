using System.Linq;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SkillAction_One : BaseSkillAction
    {
        public override string ActionId => "A-SKL-001";
        private TileArea _actionArea = new TileArea
        {
            Left = 2,
            UpLeft = 2,
            DownLeft = 2
        };
        public override ITileArea ActionArea => _actionArea;
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
