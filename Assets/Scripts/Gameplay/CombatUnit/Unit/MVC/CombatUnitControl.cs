using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport;
using CombTeen.Gameplay.StateRunner;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC.Data;
using UnityEngine;
using VContainer;

namespace CombTeen.Gameplay.Unit.MVC
{
    public abstract class CombatUnitControl : MonoBehaviour
    {
        public abstract string UnitId { get; }
        protected CombatUnitModel Data;
        [SerializeField] protected CombatUnitView View;
        [SerializeField] protected CombatUnitIndicatorView StatusIndicator;
        [SerializeField] public CombatCanvasView CanvasView;

        protected ITileController TileControl;
        protected BasicCombatRunner CombatRunner;

        public string viewName => View.name;
        public IUnitBasicInfoData UnitBasicInfoData => Data;
        public IUnitTileData UnitTileData => Data;
        public IUnitStatusData UnitStatusData => Data;
        public IUnitActionData UnitActionData => Data;

        public bool IsFacingLeft { get; private set; } = true;

        [Inject]
        public void Inject(ITileController tileController, BasicCombatRunner combatRunner)
        {
            TileControl = tileController;
            CombatRunner = combatRunner;
        }

        public virtual void InitialUnitData(UnitPlayData.CharacterData Character)
        {
            Data = new CombatUnitModel();
            Data.InitializeBasicInfo(Character.CharacterId, Character.CharacterName);
            CanvasView.SetName(Character.CharacterName);
            StatusIndicator.SetUnitName(Character.CharacterName);

            List<BaseSkillAction> skills = new List<BaseSkillAction>();
            for (int i = 0; i < Character.SkillsAction.Length; i++)
            {
                skills.Add((BaseSkillAction)Character.SkillsAction[i].GenerateLogic(this));
            }

            Data.InitializeAction(attack: Character.AttackAction.GenerateLogic(this),
                                  defense: Character.DefenseAction.GenerateLogic(this),
                                  support: Character.SupportAction.GenerateLogic(this),
                                  skills: skills,
                                  move: Character.MoveAction.GenerateLogic(this),

                                  CombatRunner.OnChangeNextTurn);

            Data.InitializeStat(Character.BasicStatus);

            Data.ChangeCombatStatusAction.AfterTakeDamageEvent.AddListener(CheckUnitDie);
        }
        public void SetLocation(ActionTileObject targetTile)
        {
            if (targetTile == null) return;

            TileControl.SetOccupiedTile(targetTile, Data.CurrentTile, this);
            Data.SetWorldPosition(targetTile);
            Data.SetUnitOccupiedTile(targetTile);

            View.transform.localPosition = new UnityEngine.Vector3(
            targetTile.TileWorldPosition.x
            , View.transform.localPosition.y,
            targetTile.TileWorldPosition.z);
        }

        public void SetFacing(bool facingLeft)
        {
            IsFacingLeft = facingLeft;
            View.SetFacing(facingLeft);
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
