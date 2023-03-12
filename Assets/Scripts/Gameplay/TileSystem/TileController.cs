using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Tile.Object;
using UnityEngine;
using VContainer.Unity;

namespace CombTeen.Gameplay.Tile
{
    public interface ITileController
    {

    }
    public class TileController : IStartable, ITileController
    {
        private TileModelData _tilesData;
        private IReadOnlyList<ActionTileObject> _allTiles;

        public TileController(IReadOnlyList<ActionTileObject> allTiles)
        {
            _allTiles = allTiles;
        }

        public void Start()
        {
            _tilesData = new TileModelData();
            for (int i = 0; i < _allTiles.Count; i++)
            {
                _allTiles[i].ChangeColor(Color.red);
            }
        }
    }
}
