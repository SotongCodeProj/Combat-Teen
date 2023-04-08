using System.Collections.Generic;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Status;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.MVC.Data
{
    #region Get
    public interface IUnitBasicInfoData
    {
        public string PlayerId { get; }
        public string UnitName { get; }
    }
    public interface IUnitStatusData
    {
        public IBasicStat CombatStat { get; }
        public IBasicStat BaseStatus { get; }
        public IUnitModifAction ChangeBaseParameterAction { get; }
        public IUnitCombatStatModifAction ChangeCombatStatusAction { get; }
    }
    public interface IUnitActionData
    {
        public BaseAttackAction AttackAction { get; }
        public BaseDefenseAction DefenseAction { get; }
        public IReadOnlyList<BaseSkillAction> SkillActions { get; }
        public BaseSupportAction SupportAction { get; }
        public BaseMoveAction MoveAction { get; }

        public BaseUnitAction UsedAction { get; }

        public BaseAttackAction SetAttackAction();
        public BaseSkillAction SetSkillAction(int index);
        public BaseDefenseAction SetDefeseAction();
        public BaseSupportAction SetSupportAction();
        public BaseMoveAction SetMoveAction();

    }
    public interface IUnitTileData
    {
        Vector2Int Coordinate { get; }
        ActionTileObject CurrentTile { get; }
    }
    #endregion
}
