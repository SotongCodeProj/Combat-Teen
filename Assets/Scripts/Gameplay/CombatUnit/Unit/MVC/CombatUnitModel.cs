using System.Collections.Generic;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Status;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitModel
    {
        public string PlayerId;
        public string UnitName;

        private BaseUnitStat BaseUnitSatus;
        private DynamicUnitStat DynamicUnitStatus;
        public IUnitModifAction ModifStatusAction => DynamicUnitStatus;
        public FinalUniStat FinalStatus { private set; get; }

        #region  Action
        public BaseAttackAction AttackAction { private set; get; }
        public BaseDefenseAction DefenseAction { private set; get; }
        public IReadOnlyList<BaseSkillAction> SkillActions { private set; get; }
        public BaseSupportAction SupportAction { private set; get; }
        #endregion

        public BaseUnitAction UsedAction { private set; get; }


        public T SetAction<T>(T action) where T: BaseUnitAction
        {
            UsedAction = action;
            return UsedAction as T;
        }
        public void InitializeAction(BaseAttackAction attack,
                               BaseDefenseAction defense,
                               BaseSupportAction supportAction,
                               BaseSkillAction[] skillActions)
        {
            AttackAction = attack;
            DefenseAction = defense;
            SupportAction = supportAction;
            SkillActions = new List<BaseSkillAction>(skillActions);
        }
        public void InitializeStat(IBasicStat basicStat)
        {
            BaseUnitSatus = new BaseUnitStat(
                basicStat.Attack,
                basicStat.Defense,
                basicStat.Health,
                basicStat.Speed,
                basicStat.Ap
            );

            FinalStatus = new FinalUniStat(BaseUnitSatus, DynamicUnitStatus);
        }

        #region  Test

        #endregion
    }
}