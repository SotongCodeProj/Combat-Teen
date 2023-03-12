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
            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            UILogger.Instance.LogSub($"{Owner.Data.UnitName} Deal Damge using Simple Skill to {TargetUnits.Data.UnitName}",true);
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
