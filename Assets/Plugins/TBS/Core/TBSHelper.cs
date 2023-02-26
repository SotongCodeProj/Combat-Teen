using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TBS.Core;
using TBS.Core.StateCollection;
using TBS.Basic;
using TBS.Core.Runner;

namespace TBS.Helper
{
    public static class TBSHelper
    {
        public static void AddStateLoopState<M>(this IStateProcessor<M> processor,
        ILoopState state, int index = -1) where M : IStateTurnModel

        {
            var listData = processor.Data.LoopStates.ToList<ILoopState>();
            if (index < 0) { listData.Add(state); return; }
            listData.Insert(index, state);
        }

        public static void RemoveState<M>(this IStateProcessor<M> processor,
        int index) where M : IStateTurnModel
        {
            var listData = processor.Data.LoopStates.ToList<ILoopState>();
            if (index < 0) return;
            listData.RemoveAt(index);
        }

        public static void RemoveState<M>(this IStateProcessor<M> processor,
        string stateId) where M : IStateTurnModel
        {
            processor.RemoveState((processor.Data.LoopStates as List<ILoopState>).FindIndex(x => x.StateId.Equals(stateId)));
        }

        public static void RemoveStates<M>(this IStateProcessor<M> processor,
        params int[] indexs) where M : IStateTurnModel
        {
            for (int i = 0; i < indexs.Length; i++)
            {
                processor.RemoveState(indexs[i]);
            }
        }

        public static void RemoveStates<M>(this IStateProcessor<M> processor,
        params string[] stateIds) where M : IStateTurnModel
        {
            for (int i = 0; i < stateIds.Length; i++)
            {
                processor.RemoveState(stateIds[i]);
            }
        }

        #region  Editor
#if UNITY_EDITOR
        [MenuItem("TBS/Create Basic Requeirement SO's", false, -1)]
        public static void CreateBasicSO()
        {
            string stateLocation = $"Assets/TBS/SO_Object/State Collections";
            string runnerLocation = $"Assets/TBS/SO_Object/Basic";

            List<ScriptableObject> states = new List<ScriptableObject>();
            List<ScriptableObject> runners = new List<ScriptableObject>();

            states.Add(ScriptableObject.CreateInstance<StartBattle>());
            states.Add(ScriptableObject.CreateInstance<PlayerTurn>());
            states.Add(ScriptableObject.CreateInstance<EnemyTurn>());
            states.Add(ScriptableObject.CreateInstance<EndBattle>());

            runners.Add(ScriptableObject.CreateInstance<TBS_BasicRunner>());
            runners.Add(ScriptableObject.CreateInstance<TBS_BasicModel>());

            for (int i = 0; i < states.Count; i++)
            {
                AssetDatabase.CreateAsset(states[i], $"{stateLocation}/{states[i].GetType().Name}State.asset");
                AssetDatabase.SaveAssets();
            }
            for (int i = 0; i < runners.Count; i++)
            {
                AssetDatabase.CreateAsset(runners[i], $"{runnerLocation}/{runners[i].GetType().Name}.asset");
                AssetDatabase.SaveAssets();
            }
        }

#endif
        #endregion
    }


}
