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
        void ShowTileArea(Vector2Int ancorPos, ITileArea showArea);
    }

    public class TileController : ITileController
    {
        private List<ActionTileObject> _currentActiveTile = new List<ActionTileObject>();
        private TileModelData _tileData;
        public TileController(IReadOnlyList<ActionTileObject> allTiles)
        {
            _tileData = new TileModelData(allTiles, new Vector2Int(9, 5));

        }
        public void ShowTileArea(Vector2Int ancorPos, ITileArea showArea)
        {
            for (int i = 0; i < _currentActiveTile.Count; i++)
            {
                _currentActiveTile[i].ChangeColorToDefault();
            }
            _currentActiveTile.Clear();

            var result = TileSystemHelper.CalculateTilePosition(ancorPos, showArea, new Vector2Int(9, 5));
            for (int i = 0; i < result.Count; i++)
            {
                var selectedTile = _tileData.AllTiles[result[i]];

                selectedTile.ChangeColor(Color.red);
                _currentActiveTile.Add(selectedTile);
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

        public IActionTileData SetOccupiedTile(IActionTileData newTile, IActionTileData oldTile, CombatUnitControl combatUnitControl)
        {
            _tileData.AllTiles[oldTile.TileCoordinate].SetOccuppiedUnit(combatUnitControl);
            _tileData.AllTiles[newTile.TileCoordinate].SetOccuppiedUnit(combatUnitControl);
            return newTile;
        }
    }
}
