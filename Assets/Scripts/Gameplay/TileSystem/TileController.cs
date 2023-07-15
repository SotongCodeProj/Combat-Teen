using System.Collections.Generic;
using System.Linq;
using CombTeen.Gameplay.Tile.Helper;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;

namespace CombTeen.Gameplay.Tile
{
    public interface ITileController
    {
        ActionTileObject Test_GetRandomTile();
        IEnumerable<ActionTileObject> Test_GetAllTile();
        void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse = false);
        public void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse, out IEnumerable<CombatUnitControl> unitsOnTile);
        public void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse, out IEnumerable<ActionTileObject> clickAbleTile);
        ActionTileObject SetOccupiedTile(ActionTileObject targetTile, ActionTileObject currentTile, CombatUnitControl combatUnitControl);
        void ClearShowTile();
    }

    public class TileController : ITileController
    {
        private List<ActionTileObject> _currentActiveTile = new List<ActionTileObject>();
        private TileModelData _tileData;
        public TileController(IReadOnlyList<ActionTileObject> allTiles)
        {
            _tileData = new TileModelData(allTiles, new Vector2Int(7, 5));

        }
        public void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse = false)
        {
            for (int i = 0; i < _currentActiveTile.Count; i++)
            {
                _currentActiveTile[i].ChangeColorToDefault();
            }
            _currentActiveTile.Clear();

            var result = TileSystemHelper.CalculateTilePosition(ancorPos, showArea, new Vector2Int(7, 5), reverse);
            foreach (var tile in result)
            {
                var selectedTile = _tileData.AllTiles[tile];

                selectedTile.ChangeColor(Color.red);
                _currentActiveTile.Add(selectedTile);
            }
        }
        public void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse, out IEnumerable<CombatUnitControl> unitsOnTile)
        {
            unitsOnTile = new List<CombatUnitControl>();
            List<CombatUnitControl> units = new List<CombatUnitControl>();
            ShowTileArea(ancorPos, showArea, reverse);

            for (int i = 0; i < _currentActiveTile.Count; i++)
            {
                if (_currentActiveTile[i].OccupiedUnit != null)
                    units.Add(_currentActiveTile[i].OccupiedUnit);

            }
            unitsOnTile = units;
        }
        public void ShowTileArea(Vector2Int ancorPos, IEnumerable<Vector2Int> showArea, bool reverse, out IEnumerable<ActionTileObject> clickAbleTile)
        {
            clickAbleTile = new List<ActionTileObject>();
            List<ActionTileObject> tileObjects = new List<ActionTileObject>();
            ShowTileArea(ancorPos, showArea, reverse);

            for (int i = 0; i < _currentActiveTile.Count; i++)
            {
                tileObjects.Add(_currentActiveTile[i]);
            }
            clickAbleTile = tileObjects;
        }

        public void ClearShowTile()
        {
            foreach (var item in _currentActiveTile)
            {
                item.ChangeColorToDefault();
            }
        }
        public IEnumerable<ActionTileObject> Test_GetAllTile()
        {
            return _tileData.AllTiles.Values.Where(x => { return true; });
        }

        public ActionTileObject Test_GetRandomTile()
        {

            ActionTileObject randomTile;
            do
            {
                randomTile = _tileData.AllTiles.ElementAt(Random.Range(0, _tileData.AllTiles.Count)).Value;
            }
            while (randomTile.OccupiedUnit != null);
            return randomTile;
        }

        public ActionTileObject SetOccupiedTile(ActionTileObject newTile, ActionTileObject oldTile, CombatUnitControl combatUnitControl)
        {
            if (oldTile != null) _tileData.AllTiles[oldTile.TileCoordinate].SetOccuppiedUnit(null);
            _tileData.AllTiles[newTile.TileCoordinate].SetOccuppiedUnit(combatUnitControl);

            return newTile;
        }
    }
}
