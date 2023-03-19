using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;


namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleDefenseAction : BaseDefenseAction
    {
        public override string ActionId => "A-DEF-000";
        public override ITileArea ActionArea => new TileArea{};
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
            UILogger.Instance.LogSub($"{ActionId} will do defense action from {Owner.UnitBasicInfoData.UnitName}",true);
            return UniTask.Delay(500);
        }

        public override BaseDefenseAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleDefenseAction()
            {
                Owner = owner
            };
        }
    }
}
