using System.Collections.Generic;
using CombTeen.Constant;
using CombTeen.Esential.ActionSystem;
using UnityEngine;

namespace CombTeen.Esential.StyleSystem
{
    [CreateAssetMenu(menuName = "CombTeen/Style", fileName ="STY-000")]
    public class StyleDataSO : ScriptableObject, IStyleModel
    {
        public string Id => _id;
        public IEnumerable<ClassType> CompactibleClassType => _compactibleClassType;
        public IEnumerable<ActionDataSO> ActionIds => _actions;


        [SerializeField] private string _id;
        [SerializeField] private ClassType[] _compactibleClassType;
        [SerializeField] private ActionDataSO[] _actions = new ActionDataSO[5];


    }
}   
