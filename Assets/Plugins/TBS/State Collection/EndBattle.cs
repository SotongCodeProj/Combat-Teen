using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TBS.Core.StateCollection
{
    public class EndBattle :ScriptableObject, IEndState
    {
        public virtual string StateId => "end-battle";
        
        UniTask IState.PreState => this.PreState();
        UniTask IState.ProcessSate => this.ProcessState();
        UniTask IState.PostState => this.PostState();
        protected virtual UniTask PreState()
        {
            Debug.Log($"Pre State : {StateId}");
            return UniTask.CompletedTask;
        }

        protected virtual UniTask ProcessState()
        {
            Debug.Log($"Running State : {StateId}\n" +
            $"Here run the Main logic of This State");

            return UniTask.CompletedTask;
        }
        protected virtual UniTask PostState()
        {
            Debug.Log($"Post State : {StateId}");
            return UniTask.CompletedTask;
        }

        public virtual ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
