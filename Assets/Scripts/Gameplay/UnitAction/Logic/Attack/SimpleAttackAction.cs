using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{

    public class SimpleAttackAction : BaseAttackAction
    {
        public override string ActionId => "A-ATK-000";

        public override ITileArea ActionArea => new TileArea{
            Up=1,
            Down=1,
            Left =1,
            Right=1,

            DownLeft=1,
            DownRight =1,
            UpLeft=1,
            UpRight=1
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
            UILogger.Instance.LogSub($"{Owner.UnitBasicInfoData.UnitName} Deal Damge using Simple Attack to {TargetUnits.UnitBasicInfoData.UnitName}",true);

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
