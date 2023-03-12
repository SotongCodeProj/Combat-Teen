using System.Collections.Generic;
using CombTeen.Gameplay.Tile.Object;

namespace CombTeen.Gameplay.Tile
{
    public interface ITileController
    {

    }
    public class TileController : ITileController
    {
        private TileModelData _tilesData;
        private IReadOnlyList<ActionTileObject> _allTiles;

        public TileController(IReadOnlyList<ActionTileObject> allTiles)
        {
            _allTiles = allTiles;
        }
    }
}
