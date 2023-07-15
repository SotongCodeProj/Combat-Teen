using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SupBuffAction : BaseSupportAction
    {

        private AdditionalStatData _statAdding = new AdditionalStatData
        {
            MaxHealth = 50,

            Attack = 3,
            Defense = 3,
            Speed = 2
        };

        private int _currentCountter = 0;

        protected override UniTask PreState()
        {
            OnChangeTurn.RemoveListener(CountBuff);
            OnChangeTurn.AddListener(CountBuff);
            Debug.Log($"Status {Owner.UnitBasicInfoData.UnitName} about to Change : {Owner.UnitStatusData.BaseStatus.Attack}");
            return UniTask.CompletedTask;
        }
        protected override UniTask PostState()
        {
            Debug.Log($"Status {Owner.UnitBasicInfoData.UnitName} Has Change : {Owner.UnitStatusData.BaseStatus.Attack}");
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            Owner.UnitStatusData.ChangeBaseParameterAction.AddMaxHealth(_statAdding.MaxHealth);

            Owner.UnitStatusData.ChangeBaseParameterAction.AddAttack(_statAdding.Attack);
            Owner.UnitStatusData.ChangeBaseParameterAction.AddDefense(_statAdding.Defense);
            Owner.UnitStatusData.ChangeBaseParameterAction.AddSpeed(_statAdding.Speed);

            _currentCountter = 2;
            return UniTask.Delay(500);
        }

        public override void SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            targetChooseHelper.OnSelectTargets.RemoveAllListeners();
            targetChooseHelper.OnSelectTargets.AddListener(
            (targets) =>
            {
                TargetUnits = targets;
            });
            targetChooseHelper.GetSelfTarget(Owner, TileArea.BasicArea);

        }

        private void CountBuff(int turnCount)
        {
            _currentCountter -= 1;
            if (_currentCountter <= 0)
            {

                Owner.UnitStatusData.ChangeBaseParameterAction.AddMaxHealth(-_statAdding.MaxHealth);

                Owner.UnitStatusData.ChangeBaseParameterAction.AddAttack(-_statAdding.Attack);
                Owner.UnitStatusData.ChangeBaseParameterAction.AddDefense(-_statAdding.Defense);
                Owner.UnitStatusData.ChangeBaseParameterAction.AddSpeed(-_statAdding.Speed);
                OnChangeTurn.RemoveListener(CountBuff);
            }
        }

        public struct AdditionalStatData
        {
            public int MaxHealth;

            public int Attack;
            public int Defense;
            public int Speed;
        }
    }
}