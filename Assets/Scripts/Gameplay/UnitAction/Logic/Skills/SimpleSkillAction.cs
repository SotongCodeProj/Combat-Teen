using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    // [CreateAssetMenu(menuName = "Test/Simple Unit State")]
    public class SimpleSkillAction : BaseSkillAction
    {
        public override string ActionId => "A-SKL-000";
        public override ITileArea ActionArea => new TileArea{
            Up=2,
            Down=2,
            Left =2,
            Right=2,

            DownLeft=2,
            DownRight =2,
            UpLeft=2,
            UpRight=2
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
            UILogger.Instance.LogSub($"{Owner.UnitBasicInfoData.UnitName} Deal Damge using Simple Skill to {TargetUnits.UnitBasicInfoData.UnitName}",true);
            return UniTask.Delay(500);
        }

        public override BaseSkillAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleSkillAction()
            {
                Owner = owner
            };
        }
    }
}
