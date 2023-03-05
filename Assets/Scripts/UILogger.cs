using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CombTeen
{
    public class UILogger : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _mainTextLog;
        [SerializeField] TextMeshProUGUI _subTextLog;

        public static UILogger Instance;

        private void Awake()
        {
            Instance = this;
        }
        public void LogMain(string messege)
        {
            _mainTextLog.text = messege;
        }
        public void LogSub(string messege, bool continueMessege = false)
        {
            if (continueMessege) _subTextLog.text += $"\n{messege}";
            else _subTextLog.text = messege;
        }
    }
}
