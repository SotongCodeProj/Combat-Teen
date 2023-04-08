using System.Linq;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action.Logic
{

    public class SimpleAttackAction : BaseAttackAction
    {
        public override string ActionId => "A-ATK-000";

        public override ITileArea ActionArea => new TileArea
        {
            Up = 1,
            Down = 1,
            Left = 1,
            Right = 1,

            DownLeft = 1,
            DownRight = 1,
            UpLeft = 1,
            UpRight = 1
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
            TargetUnits.ElementAt(0).UnitStatusData.ChangeCombatStatusAction.TakeDamage(10);
            return UniTask.Delay(500);
        }

        public override BaseUnitAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleAttackAction()
            {
                Owner = owner
            };
        }

        public override async UniTask SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            var singleTarget = await targetChooseHelper.GetSingleTargetOpponentAsync(Owner);
            TargetUnits = new CombatUnitControl[] { singleTarget };
        }
    }
}
