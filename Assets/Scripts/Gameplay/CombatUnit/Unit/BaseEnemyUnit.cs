using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;

namespace CombTeen.Gameplay.Unit
{
    public class BaseEnemyUnit : CombatUnitControl
    {
        public override string UnitId => "Enemy";

        public override void InitialUnitData(CharacterData Character)
        {
            base.InitialUnitData(Character);
            UnitStatusData.ChangeCombatStatusAction.AfterTakeDamageEvent.AddListener(
                (newHealth) =>
                {
                    StatusIndicator.UpdateHealthView(newHealth, UnitStatusData.BaseStatus.Health);
                });
            StatusIndicator.UpdateHealthView(UnitStatusData.CombatStat.Health, UnitStatusData.BaseStatus.Health);
        }

        public BaseEnemyUnit(CombatUnitView view, CombatUnitIndicatorView indicatorView)
        {
            View = view;
            StatusIndicator = indicatorView;
        }
    }
}
