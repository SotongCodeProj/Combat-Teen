using System;
using System.Reflection;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace CombTeen.Esential.ActionSystem
{
    public abstract class ActionDataSO : ScriptableObject
    {
        public string ActionId;
        public string ActionName;

        public Vector2Int[] BasicArea;
        [SerializeField] protected string _logicReference;
#if UNITY_EDITOR
        public MonoScript _logicScript;
#endif

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (_logicScript == null) return;
        }
#endif
        protected T CreateLogic<T>(CombatUnitControl requester) where T : BaseUnitAction
        {
            if (string.IsNullOrEmpty(_logicReference))
            {
                throw new System.InvalidOperationException("Reference of Logic is NULL. Check the reference data");
            }

            var baseType = Type.GetType(_logicReference);
            var logicObject = System.Activator.CreateInstance(baseType) as T;

            logicObject.InitializeBaseData(ActionId);
            logicObject.InitializeArea(BasicArea);
            logicObject.InitializeOwner(requester);
            // rawAction.InitializeChangeTurnEvent(changeTurnEvent);

            return logicObject as T;
        }
    }
}
