using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitModel
    {
        public string PlayerId;
        public string UnitName;
        public BaseAttackAction AttackAction { private set; get; }
        public BaseDefenseAction DefenseAction { private set; get; }
        public  IReadOnlyList<BaseSkillAction> SkillActions { private set; get; }
        public BaseSupportAction SupportAction { private set; get; }

        public BaseUnitAction UsedAction { private set; get; }

        public void SetAction(BaseUnitAction action)
        {
            UsedAction = action;
        }
        public void Initialize(BaseAttackAction attack,
                               BaseDefenseAction defense,
                               BaseSupportAction supportAction,
                               BaseSkillAction[] skillActions)
        {
            AttackAction = attack;
            DefenseAction = defense;
            SupportAction = supportAction;
            SkillActions = new List<BaseSkillAction>(skillActions);
        }

        #region  Test
        private List<BaseUnitAction> _allAvailableAction = new List<BaseUnitAction>();
        private BaseUnitAction RandomizeAction()
        {
            if (_allAvailableAction.Count <= 0)
            {
                _allAvailableAction.Add(AttackAction);
                _allAvailableAction.Add(DefenseAction);
                _allAvailableAction.Add(SupportAction);
                _allAvailableAction.AddRange(SkillActions);
            }
            return _allAvailableAction[Random.Range(0, _allAvailableAction.Count)];
        }
        #endregion
    }
}