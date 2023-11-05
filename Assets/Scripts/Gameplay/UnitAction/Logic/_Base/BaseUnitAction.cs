using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace CombTeen.Gameplay.Unit.Action
{
    public interface IUnitAction : IAsyncDisposable
    {
        public UnityEvent<int> OnChangeTurn { get; }
        public IEnumerable<CombatUnitControl> TargetUnits { get; }

        public UniTask PreProcess { get; }
        public UniTask MainProcess { get; }
        public UniTask PostProcess { get; }
    }
    public interface IActionData
    {
        public string ActionId { get; }
        public CombatUnitControl Owner { get; }
        public TileArea TileArea { get; }

    }
    public interface IActionInitializer
    {
        public void InitializeBaseData(string actionId);
        public void InitializeOwner(CombatUnitControl owner);
        public void InitializeChangeTurnEvent(UnityEvent<int> ChangeTurnEvent);
        public void InitializeArea(IEnumerable<Vector2Int> basicArea);
    }
    public abstract class BaseUnitAction : IUnitAction, IActionData, IActionInitializer
    {
        public string ActionId { private set; get; }
        public TileArea TileArea { protected set; get; }


        public CombatUnitControl Owner { protected set; get; }
        public UnityEvent<int> OnChangeTurn { protected set; get; }
        public IEnumerable<CombatUnitControl> TargetUnits { protected set; get; }

        public UniTask PreProcess => PreState();
        public UniTask MainProcess => ProcessState();
        public UniTask PostProcess => PostState();


        protected virtual UniTask PreState() { return UniTask.CompletedTask; }
        protected virtual UniTask ProcessState() { return UniTask.CompletedTask; }
        protected virtual UniTask PostState() { return UniTask.CompletedTask; }


        public virtual void SetUnitTargets(TargetChooseHelper targetChooseHelper) { throw new NotImplementedException(); }

        public void InitializeOwner(CombatUnitControl owner)
        {
            Owner = owner;
        }
        public void InitializeChangeTurnEvent(UnityEvent<int> ChangeTurnEvent)
        {
            OnChangeTurn = ChangeTurnEvent;
        }
        public void InitializeBaseData(string actionId)
        {
            ActionId = actionId;
        }
        public void InitializeArea(IEnumerable<Vector2Int> basicArea)
        {
            TileArea = new TileArea(basicArea);
        }


        public virtual ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
