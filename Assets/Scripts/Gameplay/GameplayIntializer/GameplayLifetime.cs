using System;
using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Screen.ActionPanel;
using CombTeen.Gameplay.Unit;
using CombTeen.Gameplay.Unit.MVC;
using CombTeen.Gameplay.Unit.MVC.Factory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CombTeen.Gameplay
{
    public class GameplayLifetime : LifetimeScope
    {
        [Header("General")]
        [SerializeField] private UnityEditor.MonoScript[] _pureScripts;
        [SerializeField] private MonoBehaviour[] _monobehavScripts;

        [Header("Turn Base")]
        [SerializeField] private GameplayTurnBaseComponent _turnBaseComponents;
        [SerializeField] private UnitComponent _playerUnits;
        [SerializeField] private UnitComponent _enemyUnits;

        [Header("Tile")]
        [SerializeField] TileComponent _tileComponent;

        [Header("HUD")]
        [SerializeField] private HUDComponent _hudComponent;


        protected override void Configure(IContainerBuilder builder)
        {
            for (int i = 0; i < _pureScripts.Length; i++)
            {
                builder.Register(_pureScripts[i].GetClass(), Lifetime.Scoped);
            }
            for (int i = 0; i < _monobehavScripts.Length; i++)
            {
                builder.Register(_monobehavScripts.GetType(), Lifetime.Scoped);
            }

            RegisterTurnBasedComponents(builder);
            RegisterTileComponents(builder);
            RegisterHUDComponent(builder);

            builder.Register<UnitControlFactory>(Lifetime.Scoped);

            RegisterPlayerUnits(builder);
            RegisterEnemyUnits(builder);

        }

        private void RegisterTurnBasedComponents(IContainerBuilder builder)
        {
            builder.Register(_turnBaseComponents.ModelScript.GetClass(), Lifetime.Scoped)
           .AsImplementedInterfaces()
           .AsSelf();

            builder.Register(_turnBaseComponents.RunnerScript.GetClass(), Lifetime.Scoped)
            .AsImplementedInterfaces()
            .AsSelf();

            foreach (var state in _turnBaseComponents.States)
            {
                builder.Register(state.Bridge.GetClass(), Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();
                foreach (var stateComp in state.AdditionalComponents)
                {
                    builder.Register(stateComp.GetClass(), Lifetime.Scoped)
                    .AsImplementedInterfaces()
                    .AsSelf();
                }
            }
        }
        
        private void RegisterPlayerUnits(IContainerBuilder builder)
        {
            var bridgeController = _playerUnits.BridgeController.GetClass();
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(bridgeController);

            var listType = typeof(List<>).MakeGenericType(bridgeController);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var unit in _playerUnits.UnitObjects)
            {
                var controller = Activator.CreateInstance(unit.UnitController.GetClass(), new[] { unit.View });
                listInstance.Add(controller);
            }
            builder.RegisterInstance(listInstance).As(readonlyList);

            builder.RegisterBuildCallback((container) =>
            {
                var players = container.Resolve<IReadOnlyList<BasePlayerUnit>>();
                foreach (var unit in players)
                {
                    container.Inject(unit);
                }
            });
        }
        private void RegisterEnemyUnits(IContainerBuilder builder)
        {
            var bridgeController = _enemyUnits.BridgeController.GetClass();
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(bridgeController);

            var listType = typeof(List<>).MakeGenericType(bridgeController);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var unit in _enemyUnits.UnitObjects)
            {
                var controller = Activator.CreateInstance(unit.UnitController.GetClass(), new[] { unit.View });
                listInstance.Add(controller);
            }
            builder.RegisterInstance(listInstance).As(readonlyList);

            builder.RegisterBuildCallback((container) =>
            {
                var enemys = container.Resolve<IReadOnlyList<BaseEnemyUnit>>();
                foreach (var unit in enemys)
                {
                    container.Inject(unit);
                }
            });
        }


        private void RegisterHUDComponent(IContainerBuilder builder)
        {
            builder.RegisterComponent<ActionPanelView>(_hudComponent.ActionPanelView).AsImplementedInterfaces();
            builder.Register(_hudComponent.ActionPanelControl.GetClass(), Lifetime.Scoped).AsImplementedInterfaces();
        }
        private void RegisterTileComponents(IContainerBuilder builder)
        {
            builder.Register(_tileComponent.TileController.GetClass(), Lifetime.Scoped).AsImplementedInterfaces();
            //Register tile Object
            var controller = _tileComponent.TileObjectBridge.GetClass();
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(controller);

            var listType = typeof(List<>).MakeGenericType(controller);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var view in _tileComponent.TileViews)
            {
                var instance = Activator.CreateInstance(controller, new object[] { view });
                listInstance.Add(instance);
            }
            builder.RegisterInstance(listInstance)
            .As(readonlyList);
        }

        protected override void Awake()
        {
            base.Awake();

        }

        [System.Serializable]
        public struct GameplayTurnBaseComponent
        {
            public UnityEditor.MonoScript RunnerScript;
            public UnityEditor.MonoScript ModelScript;

            public SateComponent[] States;
        }

        [System.Serializable]
        public struct SateComponent
        {
            public UnityEditor.MonoScript Bridge;
            public UnityEditor.MonoScript[] AdditionalComponents;
        }

        [System.Serializable]
        public struct UnitComponent
        {
            public UnityEditor.MonoScript BridgeController;
            public UnitDetail[] UnitObjects;

            [System.Serializable]
            public struct UnitDetail
            {
                public UnityEditor.MonoScript UnitController;
                public CombatUnitView View;
            }
        }

        [System.Serializable]
        public struct HUDComponent
        {
            public UnityEditor.MonoScript ActionPanelControl;
            public ActionPanelView ActionPanelView;
        }

        [System.Serializable]
        public struct TileComponent
        {
            public UnityEditor.MonoScript TileController;

            public UnityEditor.MonoScript TileObjectBridge;
            public MonoBehaviour[] TileViews;
        }
    }
}