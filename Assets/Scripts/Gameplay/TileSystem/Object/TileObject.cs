using UnityEngine;

namespace CombTeen.Gameplay.Tile.Object
{
    public interface ITileObject
    {
        public string TileId { get; }
        public Vector2Int TileCoordinate { get; }
        public Vector3 TileWorldPosition { get; }
        

    }
    public abstract class TileObject : ITileObject
    {

        public string TileId { private set; get; }
        public Vector2Int TileCoordinate { private set; get; }

        public abstract Vector3 TileWorldPosition { get; }

        protected Color DefaultColor => new Color(1, 1, 1, 0.24f);
        public virtual void Initial(Vector2Int tileCoordinate)
        {
            TileCoordinate = tileCoordinate;

        }
    }
}
