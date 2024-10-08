using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC.Data;

namespace CombTeen.Gameplay.Unit.MVC
{
    public abstract class CombatUnitControl
    {
        public abstract string UnitId { get; }
        protected CombatUnitModel Data = new CombatUnitModel();
        protected CombatUnitView View;
        protected CombatUnitIndicatorView StatusIndicator;
        protected ITileController TileControl;

        public string viewName => View.name;
        public IUnitBasicInfoData UnitBasicInfoData => Data;
        public IUnitTileData UnitTileData => Data;
        public IUnitStatusData UnitStatusData => Data;
        public IUnitActionData UnitActionData => Data;

        public virtual void InitialUnitData(CharacterData Character)
        {
            Data.InitializeBasicInfo(Character.CharacterId, Character.CharacterName);

            List<BaseSkillAction> skills = new List<BaseSkillAction>();
            for (int i = 0; i < Character.SkillsAction.Length; i++)
            {
                skills.Add((BaseSkillAction)Character.SkillsAction[i].Logic.InitializeOwner(this));
            }

            Data.InitializeAction((BaseAttackAction)Character.AttackAction.Logic.InitializeOwner(this),
                                  (BaseDefenseAction)Character.DefenseAction.Logic.InitializeOwner(this),
                                  (BaseSupportAction)Character.SupportAction.Logic.InitializeOwner(this),
                                   skills.ToArray(),
                                  (BaseMoveAction)Character.MoveAction.Logic.InitializeOwner(this));

            Data.InitializeStat(Character.BasicStatus);

            Data.ChangeCombatStatusAction.AfterTakeDamageEvent.AddListener(CheckUnitDie);
        }
        public void SetLocation(ActionTileObject targetTile)
        {
            TileControl.SetOccupiedTile(targetTile, Data.CurrentTile, this);
            Data.SetWorldPosition(targetTile);
            Data.SetUnitOccupiedTile(targetTile);

            View.transform.localPosition = new UnityEngine.Vector3(
            targetTile.TileWorldPosition.x
            , View.transform.localPosition.y,
            targetTile.TileWorldPosition.z);
        }

        private void CheckUnitDie(int currentHelth)
        {
            if (currentHelth <= 0)
            {
                View.SetUnitDie();
                UnitTileData.CurrentTile.SetOccuppiedUnit(null);
            }
        }
    }
}
