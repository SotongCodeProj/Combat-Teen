using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TBS.Basic;
using UnityEngine;

namespace TBS.Sample
{
    public class TBS_InspectorDebugger : MonoBehaviour
    {
        [SerializeField] private TBS_BasicRunner runner;
        [SerializeField] private TBS_BasicModel data;

        [Button]
        private async void Test()
        {
            runner.Initialize(data);
            await runner.BeginProcess();
        }
        [Button]
        private void NextOnLoop()
        {
            runner.Next();
        }

    }
}
