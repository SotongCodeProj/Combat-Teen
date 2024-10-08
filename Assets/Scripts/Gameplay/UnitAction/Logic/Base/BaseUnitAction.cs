using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CombTeen.Gameplay.Unit.Action
{
    public interface IUnitAction : IAsyncDisposable
    {
        public CombatUnitControl Owner { get; }
        public string ActionId { get; }

        public UniTask PreProcess { get; }
        public UniTask MainProcess { get; }
        public UniTask PostProcess { get; }
    }
    public abstract class BaseUnitAction : IUnitAction
    {
        public CombatUnitControl Owner { protected set; get; }
        public abstract string ActionId { get; }
        public IEnumerable<CombatUnitControl> TargetUnits { protected set; get; }

        public abstract ITileArea ActionArea { get; }

        public UniTask PreProcess => PreState();
        public UniTask MainProcess => ProcessState();
        public UniTask PostProcess => PostState();

        protected abstract UniTask PreState();
        protected abstract UniTask ProcessState();
        protected abstract UniTask PostState();

        public abstract UniTask SetUnitTargets(TargetChooseHelper targetChooseHelper);
        public abstract BaseUnitAction InitializeOwner(CombatUnitControl owner);

        public virtual ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
