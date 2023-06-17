using System;
using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Screen.ActionPanel;
using CombTeen.Gameplay.State;
using CombTeen.Gameplay.StateRunner;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CombTeen.Gameplay
{
    public class GamelplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private CombatUnitControl[] _playerUnits;
        [SerializeField] private CombatUnitControl[] _enemyUnits;

        [SerializeField] private ActionTileObject[] _actionTile;

        [SerializeField] private ActionPanelView _actionPanelView;

        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureUnit(builder);
            ConfigureTurnBaseComponent(builder);
            ConfigureTileComponent(builder);
            ConfigureHUD(builder);
        }

        private void ConfigureUnit(IContainerBuilder builder)
        {
            builder.Register<CombatUnitsHandler>(Lifetime.Scoped).AsSelf();
            builder.Register<TargetChooseHelper>(Lifetime.Scoped).AsSelf();

            RegisteUnit<BasePlayerUnit>(_playerUnits, builder);
            RegisteUnit<BaseEnemyUnit>(_enemyUnits, builder);
        }
        private void RegisteUnit<T>(IEnumerable<CombatUnitControl> unitComponents, IContainerBuilder builder) where T : CombatUnitControl
        {
            var bridgeController = typeof(T);
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(bridgeController);

            var listType = typeof(List<>).MakeGenericType(bridgeController);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var unit in unitComponents)
            {
                listInstance.Add(unit);
            }
            builder.RegisterInstance(listInstance).As(readonlyList);

            builder.RegisterBuildCallback((container) =>
            {
                var enemys = container.Resolve<IReadOnlyList<T>>();
                foreach (var unit in enemys)
                {
                    container.Inject(unit);
                }
            });
        }


        private void ConfigureTurnBaseComponent(IContainerBuilder builder)
        {
            builder.Register<BasicCombatRunner>(Lifetime.Scoped).AsSelf();

            builder.Register<BasicStartBattleState>(Lifetime.Scoped).AsSelf();

            builder.Register<UnitsActionState>(Lifetime.Scoped).AsSelf();
            builder.Register<CheckBattleStatusState>(Lifetime.Scoped).AsSelf();

            builder.Register<BasicEndBattleState>(Lifetime.Scoped).AsSelf();

        }


        private void ConfigureTileComponent(IContainerBuilder builder)
        {
            builder.Register<TileController>(Lifetime.Scoped).AsImplementedInterfaces();
            RegisterTileObject(builder);

        }
        private void RegisterTileObject(IContainerBuilder builder)
        {
            var controller = typeof(ActionTileObject);
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(controller);

            var listType = typeof(List<>).MakeGenericType(controller);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var tile in _actionTile)
            {
                listInstance.Add(tile);
            }
            builder.RegisterInstance(listInstance)
            .As(readonlyList);
        }


        private void ConfigureHUD(IContainerBuilder builder)
        {
            builder.RegisterComponent<ActionPanelView>(_actionPanelView).AsImplementedInterfaces();
            builder.Register<ActionPanelController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }

}
