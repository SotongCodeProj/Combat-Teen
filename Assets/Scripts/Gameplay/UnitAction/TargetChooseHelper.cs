using Cysharp.Threading.Tasks;
using CombTeen.Gameplay.Unit.MVC;
using System.Collections.Generic;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using System.Threading;

namespace CombTeen.Gameplay.Unit.Action.Helper
{
    public class TargetChooseHelper
    {
        private ITileController _tileControl;
        private CombatUnitsHandler _unitHandler;

        public TargetChooseHelper(ITileController tileController, CombatUnitsHandler unitHandler)
        {
            _tileControl = tileController;
            _unitHandler = unitHandler;
        }

        public async UniTask<CombatUnitControl> GetSelfTargetAsync(CombatUnitControl requester)
        {
            using var baseCts = new CancellationTokenSource();
            CombatUnitControl target = null;

            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea);

            baseCts.Token.ThrowIfCancellationRequested();
            requester.UnitTileData.CurrentTile.OnClickEvent.AddListener((selectedTile) =>
            {
                target = selectedTile.OccupiedUnit;
            });
            var process = requester.UnitTileData.CurrentTile.OnClickEvent.OnInvokeAsync(baseCts.Token);

            await UniTask.WhenAny(process).SuppressCancellationThrow();
            return target;
        }
        public async UniTask<CombatUnitControl> GetSingleTargetAllyAsync(CombatUnitControl requester)
        {
            using var baseCts = new CancellationTokenSource();
            CombatUnitControl target = null;

            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea,
              out IEnumerable<ActionTileObject> clickAbleTile);

            List<UniTask> process = new List<UniTask>();

            baseCts.Token.ThrowIfCancellationRequested();
            foreach (var item in clickAbleTile)
            {
                var detectedUnit = item.OccupiedUnit;
                if (_unitHandler.IsAlly(requester, detectedUnit))
                {
                    item.OnClickEvent.AddListener((selectedTile) =>
                    {
                        target = selectedTile.OccupiedUnit;

                    });
                    process.Add(item.OnClickEvent.OnInvokeAsync(baseCts.Token));
                }
            }
            await UniTask.WhenAny(process).SuppressCancellationThrow();
            return target;
        }
        public async UniTask<CombatUnitControl> GetSingleTargetOpponentAsync(CombatUnitControl requester)
        {
            using var baseCts = new CancellationTokenSource();
            CombatUnitControl target = null;

            _tileControl.ShowTileArea(
              requester.UnitTileData.Coordinate,
              requester.UnitActionData.UsedAction.ActionArea,
              out IEnumerable<ActionTileObject> clickAbleTile);

            List<UniTask> process = new List<UniTask>();

            baseCts.Token.ThrowIfCancellationRequested();
            foreach (var item in clickAbleTile)
            {
                var detectedUnit = item.OccupiedUnit;
                if (_unitHandler.IsOpponent(requester, detectedUnit))
                {
                    item.OnClickEvent.AddListener((selectedTile) =>
                    {
                        target = selectedTile.OccupiedUnit;

                    });
                    process.Add(item.OnClickEvent.OnInvokeAsync(baseCts.Token));
                }
            }
            await UniTask.WhenAny(process).SuppressCancellationThrow();
            return target;
        }

        public async UniTask<ActionTileObject> GetTileWithoutUnitAsync(CombatUnitControl requester)
        {
            using var baseCts = new CancellationTokenSource();
            ActionTileObject target = null;

            _tileControl.ShowTileArea(
            requester.UnitTileData.Coordinate,
            requester.UnitActionData.UsedAction.ActionArea,
            out IEnumerable<ActionTileObject> clickAbleTile);

            List<UniTask> process = new List<UniTask>();

            baseCts.Token.ThrowIfCancellationRequested();
            foreach (var item in clickAbleTile)
            {
                if (item.OccupiedUnit != null) continue;
                
                item.OnClickEvent.AddListener((selectedTile) =>
                {
                    target = selectedTile;
                });
                process.Add(item.OnClickEvent.OnInvokeAsync(baseCts.Token));
            }

            await UniTask.WhenAny(process).SuppressCancellationThrow();
            return target;
        }
    }
}

