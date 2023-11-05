using System.Collections.Generic;
using System.Linq;
using CombTeen.Constant;
using CombTeen.Esential.ActionSystem;
using UnityEngine;

namespace CombTeen
{
    public class TempActionDataLoader : MonoBehaviour
    {
        public static TempActionDataLoader Instance;
        [SerializeField] List<ActionDataAttack> actionDataAttacks = new();
        [SerializeField] List<ActionDataDefense> actionDataDefenses = new();
        [SerializeField] List<ActionDataSkill> actionDataSkills = new();
        [SerializeField] List<ActionDataSupport> actionDataSupports = new();
        [SerializeField] List<ActionDataMove> actionDataMoves = new();

        private List<ActionDataSO> _allData = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
                return;
            }
            _allData.AddRange(_allData
            .Concat(actionDataAttacks)
            .Concat(actionDataDefenses)
            .Concat(actionDataSkills)
            .Concat(actionDataSupports)
            .Concat(actionDataMoves));
        }

        public T GetData<T>(string Id) where T : ActionDataSO
        {
            return _allData.Find(x => x.ActionId == Id) as T;
        }

        public ActionDataSO[] GetDatas(ActionType actionType)
        {
            return _allData.FindAll(x => x.ActionType == actionType).ToArray();
        }
    }
}
