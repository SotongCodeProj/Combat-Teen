using System.Collections.Generic;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC.Data;
using CombTeen.Gameplay.Unit.Status;
using UnityEngine;
using UnityEngine.Events;

namespace CombTeen.Gameplay.Unit.MVC
{
    public class CombatUnitModel :
    IUnitBasicInfoData, IUnitStatusData, IUnitTileData, IUnitActionData
    {
        #region Basic Info
        public string PlayerId { private set; get; }
        public string UnitName { private set; get; }
        #endregion

        #region  Status
        private BaseUnitStat BaseUnitSatus;
        private DynamicUnitStat DynamicUnitStatus;
        private FinalUnitStat FinalStatus;
        private CombatUnitStat CombatStatus;

        public IUnitModifAction ChangeBaseParameterAction => DynamicUnitStatus;
        public IUnitCombatStatModifAction ChangeCombatStatusAction => CombatStatus;

        public IBasicStat BaseStatus => FinalStatus;
        public IBasicStat CombatStat => CombatStatus;

        public void InitializeStat(IBasicStat basicStat)
        {
            BaseUnitSatus = new BaseUnitStat(
                basicStat.Attack,
                basicStat.Defense,
                basicStat.Health,
                basicStat.Speed,
                basicStat.Ap
            );
            DynamicUnitStatus = new DynamicUnitStat();

            FinalStatus = new FinalUnitStat(BaseUnitSatus, DynamicUnitStatus);

            CombatStatus = new CombatUnitStat(FinalStatus);
        }

        #endregion

        #region  Action
        public BaseAttackAction AttackAction { private set; get; }
        public BaseDefenseAction DefenseAction { private set; get; }
        public IReadOnlyList<BaseSkillAction> SkillActions { private set; get; }
        public BaseSupportAction SupportAction { private set; get; }
        public BaseMoveAction MoveAction { private set; get; }

        public BaseUnitAction UsedAction { private set; get; }

        public void InitializeAction(BaseAttackAction attack,
                               BaseDefenseAction defense,
                               BaseSupportAction supportAction,
                               BaseSkillAction[] skillActions,
                               BaseMoveAction moveAction,

                               UnityEvent<int> ChangeTurnEvent)
        {
            AttackAction = attack;
            DefenseAction = defense;
            SupportAction = supportAction;
            MoveAction = moveAction;
            SkillActions = new List<BaseSkillAction>(skillActions);

            AttackAction.InitializeChangeTurnEvent(ChangeTurnEvent);
            DefenseAction.InitializeChangeTurnEvent(ChangeTurnEvent);
            SupportAction.InitializeChangeTurnEvent(ChangeTurnEvent);

            foreach (var skill in SkillActions)
            {
                skill.InitializeChangeTurnEvent(ChangeTurnEvent);
            }
        }

        public BaseAttackAction SetAttackAction()
        {
            UsedAction = AttackAction;
            return AttackAction;
        }
        public BaseSkillAction SetSkillAction(int index)
        {
            UsedAction = SkillActions[index];
            return SkillActions[index];
        }
        public BaseDefenseAction SetDefeseAction()
        {
            UsedAction = DefenseAction;
            return DefenseAction;
        }
        public BaseSupportAction SetSupportAction()
        {
            UsedAction = SupportAction;
            return SupportAction;
        }
        public BaseMoveAction SetMoveAction()
        {
            UsedAction = MoveAction;
            return MoveAction;
        }


        #endregion

        #region  Tile
        public Vector2Int Coordinate { protected set; get; }

        public ActionTileObject CurrentTile { private set; get; }

        public void SetWorldPosition(ITileObject targetTile)
        {
            Coordinate = new Vector2Int(targetTile.TileCoordinate.x, targetTile.TileCoordinate.y);
        }

        public void InitializeBasicInfo(string playerId, string characterName)
        {
            UnitName = characterName;
            PlayerId = playerId;
        }

        public void SetUnitOccupiedTile(ActionTileObject tileObject)
        {
            CurrentTile = tileObject;
        }
        #endregion
    }
}