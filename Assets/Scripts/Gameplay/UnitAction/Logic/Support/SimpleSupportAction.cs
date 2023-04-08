using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleSupportAction : BaseSupportAction
    {
        public override string ActionId => "A-SPT-000";

        public override ITileArea ActionArea => new TileArea { };

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
            Owner.UnitStatusData.ChangeCombatStatusAction.AddHealth(10);
            return UniTask.Delay(500);
        }

        public override BaseUnitAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleSupportAction()
            {
                Owner = owner
            };
        }

        public async override UniTask SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            var target = await targetChooseHelper.GetSelfTargetAsync(Owner);
            TargetUnits = new[] { target };
        }
    }
}