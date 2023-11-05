using CombTeen.Gameplay.DataTransport;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Gameplay.Unit
{
    public class BasePlayerUnit : CombatUnitControl
    {
        public override string UnitId => "Player";

        public override void InitialUnitData(UnitPlayData.CharacterData Character)
        {
            base.InitialUnitData(Character);
            UnitStatusData.ChangeCombatStatusAction.AfterTakeDamageEvent.AddListener(
               (newHealth) =>
               {
                   StatusIndicator.UpdateHealthView(newHealth, UnitStatusData.BaseStatus.Health);
               });
            StatusIndicator.UpdateHealthView(UnitStatusData.CombatStat.Health, UnitStatusData.BaseStatus.Health);
        }

        public BasePlayerUnit(CombatUnitView view, CombatUnitIndicatorView indicatorView)
        {
            View = view;
            StatusIndicator = indicatorView;
        }
    }
}
