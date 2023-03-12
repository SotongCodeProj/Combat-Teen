using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    // [CreateAssetMenu(menuName = "Test/Simple Unit State")]
    public class SimpleSkillAction : BaseSkillAction
    {
        public override string ActionId => "A-SKL-000";

        protected override UniTask PreState()
        {
            UILogger.Instance.LogSub($"Pre-State of {ActionId} from {Owner.Data.UnitName}");
            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            UILogger.Instance.LogSub($"{ActionId} will do Skill Action from {Owner.Data.UnitName}", true);
            UILogger.Instance.LogSub($"{TargetUnits.Data.UnitName} Take Damage from Skill");
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
