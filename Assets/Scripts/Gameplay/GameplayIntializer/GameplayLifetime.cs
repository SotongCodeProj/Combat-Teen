using System;
using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Screen.ActionPanel;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameplayLifetime : LifetimeScope
{
    [Header("General")]
    [SerializeField] private UnityEditor.MonoScript[] _pureScripts;
    [SerializeField] private MonoBehaviour[] _monobehavScripts;

    [Header("Turn Base")]
    [SerializeField] private GameplayTurnBaseComponent _turnBaseComponents;
    [SerializeField] private Units _playerUnits;
    [SerializeField] private Units _enemyUnits;

    [SerializeField] private HUDComponent _hudComponent;


    protected override void Configure(IContainerBuilder builder)
    {
        for (int i = 0; i < _pureScripts.Length; i++)
        {
            builder.Register(_pureScripts[i].GetClass(), Lifetime.Scoped);
        }
        for (int i = 0; i < _monobehavScripts.Length; i++)
        {
            builder.Register(_monobehavScripts.GetType(),Lifetime.Scoped);
        }

        RegisterTurnBasedComponents(builder);
        RegisterPlayerUnits(builder);
        RegisterEnemyUnits(builder);
        RegisterHUDComponent(builder);

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
        var controller = _playerUnits.bridgeController.GetClass();
        var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(controller);

        var listType = typeof(List<>).MakeGenericType(controller);
        IList listInstance = (IList)Activator.CreateInstance(listType);

        foreach (var view in _playerUnits.unitView)
        {
            listInstance.Add(Activator.CreateInstance(controller, new object[] { view }));
        }
        builder.RegisterInstance(listInstance)
        .As(readonlyList);
    }
    private void RegisterEnemyUnits(IContainerBuilder builder)
    {
        var controller = _enemyUnits.bridgeController.GetClass();

        var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(controller);

        var listType = typeof(List<>).MakeGenericType(controller);
        IList listInstance = (IList)Activator.CreateInstance(listType);

        foreach (var view in _enemyUnits.unitView)
        {
            listInstance.Add(Activator.CreateInstance(controller, new object[] { view }));
        }
        builder.RegisterInstance(listInstance)
        .As(readonlyList);
    }

    private void RegisterHUDComponent(IContainerBuilder builder)
    {
        builder.RegisterComponent<ActionPanelView>(_hudComponent.ActionPanelView).AsImplementedInterfaces();
        builder.Register(_hudComponent.ActionPanelControl.GetClass(), Lifetime.Scoped).AsImplementedInterfaces();
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
    public struct Units
    {
        public UnityEditor.MonoScript bridgeController;
        public CombatUnitView[] unitView;
    }

    [System.Serializable]
    public struct HUDComponent
    {
        public UnityEditor.MonoScript ActionPanelControl;
        public ActionPanelView ActionPanelView;
    }

}
