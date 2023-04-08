using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;


namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleDefenseAction : BaseDefenseAction
    {
        public override string ActionId => "A-DEF-000";
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
            Owner.UnitStatusData.ChangeBaseParameterAction.AddDefense(3);
            return UniTask.Delay(500);
        }

        public override BaseUnitAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleDefenseAction()
            {
                Owner = owner
            };
        }

        public override async UniTask SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            var target = await targetChooseHelper.GetSelfTargetAsync(Owner);
            TargetUnits = new[] { target };
        }
    }
}
