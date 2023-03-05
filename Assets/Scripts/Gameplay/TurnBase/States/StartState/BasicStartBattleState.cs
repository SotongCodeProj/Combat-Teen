using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TBS.Core;
using UnityEngine;

namespace CombTeen.Gameplay.State
{
    public class BasicStartBattleState : IStartState
    {
        public virtual string StateId => "start-battle";

        UniTask IState.PreState => PreState();
        UniTask IState.ProcessSate => ProcessState();
        UniTask IState.PostState => PostState();

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

        public ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
