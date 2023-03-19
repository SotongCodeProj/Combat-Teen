using CombTeen.Gameplay.Tile;
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
            UILogger.Instance.LogSub($"{ActionId} will do Support action from {Owner.UnitBasicInfoData.UnitName}", true);
            return UniTask.Delay(500);
        }

        public override BaseSupportAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleSupportAction()
            {
                Owner = owner
            };
        }
    }
}