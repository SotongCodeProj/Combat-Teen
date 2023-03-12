using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Tile.Object
{
    public interface ITileObject
    {
        public string TileId { get; }
        public Vector2 TileCoordinate { get; }
    }
    public class TileObject : ITileObject
    {
        public string TileId { private set; get; }
        public Vector2 TileCoordinate { private set; get; }

        public virtual void Initial(Vector2 tileCoordinate)
        {
            TileCoordinate = tileCoordinate;
            TileId = $"TL-{tileCoordinate.x}_{tileCoordinate.y}";
        }
    }
}
