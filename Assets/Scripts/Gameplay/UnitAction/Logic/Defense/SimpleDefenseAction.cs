using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleDefenseAction : BaseDefenseAction
    {
        public override string ActionId => "A-DEF-000";

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
            UILogger.Instance.LogSub($"{ActionId} will do defense action from {Owner.Data.UnitName}",true);
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
