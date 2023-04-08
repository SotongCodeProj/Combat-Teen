using Cysharp.Threading.Tasks;
using CombTeen.Gameplay.Unit.MVC;
using System.Collections.Generic;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using UnityEngine.Events;

namespace CombTeen.Gameplay.Unit.Action.Helper
{
    public class TargetChooseHelper
    {
        private ITileController _tileControl;
        private CombatUnitsHandler _unitHandler;
        public UnityEvent<IEnumerable<CombatUnitControl>> OnSelectTargets { private set; get; } = new UnityEvent<IEnumerable<CombatUnitControl>>();
        public UnityEvent<IEnumerable<ActionTileObject>> OnSelectTiles { private set; get; } = new UnityEvent<IEnumerable<ActionTileObject>>();
        public UnityEvent OnClickEvent { private set; get; } = new UnityEvent();

        public TargetChooseHelper(ITileController tileController, CombatUnitsHandler unitHandler)
        {
            _tileControl = tileController;
            _unitHandler = unitHandler;
        }

        public void GetSelfTarget(CombatUnitControl requester)
        {

            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea);

            requester.UnitTileData.CurrentTile.OnClickEvent.AddListener((selectedTile) =>
            {
                OnSelectTargets?.Invoke(new[] { selectedTile.OccupiedUnit });
                OnClickEvent?.Invoke();
            });
        }

        public void GetSingleTargetAlly(CombatUnitControl requester)
        {
            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea,
              out IEnumerable<ActionTileObject> clickAbleTile);

            List<UniTask> process = new List<UniTask>();

            foreach (var item in clickAbleTile)
            {
                var detectedUnit = item.OccupiedUnit;
                if (_unitHandler.IsAlly(requester, detectedUnit))
                {
                    item.OnClickEvent.AddListener((selectedTile) =>
                   {
                       OnSelectTargets?.Invoke(new[] { selectedTile.OccupiedUnit });
                       OnClickEvent?.Invoke();
                   });
                }
            }
        }
        public void GetSingleTargetOpponent(CombatUnitControl requester)
        {
            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea,
              out IEnumerable<ActionTileObject> clickAbleTile);

            List<UniTask> process = new List<UniTask>();
            foreach (var item in clickAbleTile)
            {
                var detectedUnit = item.OccupiedUnit;
                if (_unitHandler.IsOpponent(requester, detectedUnit))
                {
                    item.OnClickEvent.AddListener((selectedTile) =>
                    {
                        OnSelectTargets?.Invoke(new[] { selectedTile.OccupiedUnit });
                        OnClickEvent?.Invoke();
                    });
                }
            }
        }

        public void GetTileWithoutUnit(CombatUnitControl requester)
        {
            _tileControl.ShowTileArea(
            requester.UnitTileData.Coordinate,
            requester.UnitActionData.UsedAction.ActionArea,
            out IEnumerable<ActionTileObject> clickAbleTile);

            foreach (var item in clickAbleTile)
            {
                if (item.OccupiedUnit != null) continue;
                item.OnClickEvent.AddListener((selectedTile) =>
                {
                    OnSelectTiles?.Invoke(new[] { selectedTile });
                    OnClickEvent?.Invoke();
                });
            }
        }
    }
}

