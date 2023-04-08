using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CombTeen.Gameplay.Unit
{
    public class BasePlayerUnit : CombatUnitControl
    {
        public override string UnitId => "Player";

        [Inject]
        public void Inject(ITileController tileController)
        {
            TileControl = tileController;
        }

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

        public BasePlayerUnit(CombatUnitView view, CombatUnitIndicatorView indicatorView)
        {
            View = view;
            StatusIndicator = indicatorView;
        }
    }
}
