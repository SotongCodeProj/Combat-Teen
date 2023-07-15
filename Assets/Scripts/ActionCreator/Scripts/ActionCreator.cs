using System.Linq;
using CombTeen.Esential.ActionSystem;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace CombTeen.ActionCreator
{
    public class ActionCreator : MonoBehaviour
    {
        #region  Input Data
        [Header("Component Reference")]
        [SerializeField] private TileManager _tileManager;

        [Header("Input Data")]
        [SerializeField] private ActionType _actionType;
        [SerializeField] private string Id;
        [SerializeField] private string Name;

        #if UNITY_EDITOR
        [SerializeField] private MonoScript LogicScript;
        #endif

        #endregion

        [Button]
        public void CreateAction()
        {
            CreateAsset();
            Debug.Log($"Action Created : [{_actionType}]-[{Id}]-[{Name}] || Coordinate {GetCoordinate()}");
        }

        private string GetCoordinate()
        {
            var result = string.Empty;
            foreach (var item in _tileManager.GetActiveTileCoordinates())
            {
                result += $"[{item.x},{item.y}]";
            }
            return result;
        }

        private void CreateAsset()
        {
            string firstSuffix;
            Object target;

            switch (_actionType)
            {
                default:
                case ActionType.Attack:
                    target = ScriptableObject.CreateInstance<ActionDataAttack>();
                    firstSuffix = "A-ATK";
                    break;

                case ActionType.Defense:
                    target = ScriptableObject.CreateInstance<ActionDataDefense>();
                    firstSuffix = "A-DEF";
                    break;

                case ActionType.Skill:
                    target = ScriptableObject.CreateInstance<ActionDataSkill>();
                    firstSuffix = "A-SKL";
                    break;

                case ActionType.Support:
                    target = ScriptableObject.CreateInstance<ActionDataSupport>();
                    firstSuffix = "A-SUP";
                    break;

                case ActionType.Move:
                    target = ScriptableObject.CreateInstance<ActionDataMove>();
                    firstSuffix = "A-MOV";
                    break;
            }

            //TODO : Need folder Check
            //TODO : Need file exist check

            var soObject = target as ActionDataSO;
            soObject.BasicArea =_tileManager.GetActiveTileCoordinates().ToArray();
            soObject.ActionId = string.Format("{0}-{1}", firstSuffix, Id);
            soObject.ActionName = Name;
            soObject._logicScript = LogicScript;

            AssetDatabase.CreateAsset(target, $"Assets/Content/ActionData/{_actionType}/{firstSuffix}-{Id}.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    public enum ActionType
    {
        Attack,
        Defense,
        Skill,
        Support,
        Move
    }
}
