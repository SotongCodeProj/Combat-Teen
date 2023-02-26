using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TBS.Core;
using UnityEngine;

namespace CombTeen.Gameplay.State
{
    public abstract class BaseLoopState : ILoopState
    {
        public abstract string StateId { get; }

        UniTask IState.PreState => PreState();
        UniTask IState.ProcessSate => ProcessState();
        UniTask IState.PostState => PostState();

        protected abstract UniTask PostState();
        protected abstract UniTask PreState();
        protected abstract UniTask ProcessState();
        public virtual ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
