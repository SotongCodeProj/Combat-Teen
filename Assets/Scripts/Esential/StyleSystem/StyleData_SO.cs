using System.Collections.Generic;
using CombTeen.Constant;
using UnityEngine;

namespace CombTeen.Esential.StyleSystem
{
    [CreateAssetMenu(menuName = "CombTeen/Style", fileName ="STY-000")]
    public class StyleData_SO : ScriptableObject, IStyleModel
    {
        public string Id => _id;
        public ClassConstant.ClassType ClassType => _classType;
        public IEnumerable<string> ActionIds => _actionIds;


        [SerializeField] private string _id;
        [SerializeField] private ClassConstant.ClassType _classType;
        [SerializeField] private string[] _actionIds;


    }
}   
