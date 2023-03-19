using System.Collections.Generic;
using System.Linq;
using CombTeen.Gameplay.Tile.Object;
using UnityEngine;

namespace CombTeen.Gameplay.Tile
{
    public class TileModelData
    {
        public Dictionary<Vector2Int, ActionTileObject> AllTiles { private set; get; } = new Dictionary<Vector2Int, ActionTileObject>();
        public TileModelData(IReadOnlyList<ActionTileObject> allTiles, Vector2Int areaSize)
        {
            int xPos = 0;
            int yPos = 0;
            foreach (var item in allTiles)
            {
                item.Initial(new Vector2Int(xPos, yPos));

                xPos++;
                if (xPos >= areaSize.x)
                {
                    yPos++;
                    xPos = 0;

                    if (yPos > areaSize.y)
                        break;
                }
                AllTiles.TryAdd(item.TileCoordinate, item);
            }
        }
    }
}

