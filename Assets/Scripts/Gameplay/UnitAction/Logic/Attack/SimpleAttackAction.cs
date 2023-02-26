using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{

    public class SimpleAttackAction : BaseAttackAction
    {
        public override string ActionId => "A-ATK-000";

        protected override UniTask PreState()
        {
            Debug.Log($"Pre-State of {ActionId} from {Owner.Data.UnitName}");
            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            Debug.Log($"{ActionId} will deal dama from {Owner.Data.UnitName}");
            return UniTask.Delay(500);
        }

        public override BaseAttackAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleAttackAction()
            {
                Owner = owner
            };
        }
    }
}
