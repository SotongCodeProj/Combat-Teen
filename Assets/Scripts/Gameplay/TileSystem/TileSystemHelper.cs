using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace CombTeen.Gameplay.Tile.Helper
{
    public class TileSystemHelper
    {
        public static List<Vector2Int> CalculateTilePosition(Vector2Int ancorPos, ITileArea area, Vector2Int limitArea)
        {
            List<Vector2Int> result = new List<Vector2Int>();

            for (int x = -area.Left; x < area.Right + 1; x++)
            {
                result.Add(new Vector2Int(
                    Mathf.Clamp(ancorPos.x + x, 0, limitArea.x - 1),
                    Mathf.Clamp(ancorPos.y, 0, limitArea.y - 1))
                );
            }

            for (int y = -area.Down; y < area.Up + 1; y++)
            {
                result.Add(new Vector2Int(
                    Mathf.Clamp(ancorPos.x, 0, limitArea.x - 1),
                    Mathf.Clamp(ancorPos.y + y, 0, limitArea.y - 1))
                );
            }

            for (int i = -area.DownLeft; i < area.UpRight + 1; i++)
            {
                result.Add(new Vector2Int(
                    Mathf.Clamp(ancorPos.x + i, 0, limitArea.x - 1),
                    Mathf.Clamp(ancorPos.y + i, 0, limitArea.y - 1))
                );
            }
            for (int i = -area.DownRight; i < area.UpLeft + 1; i++)
            {
                result.Add(new Vector2Int(
                    Mathf.Clamp(ancorPos.x - i, 0, limitArea.x - 1),
                    Mathf.Clamp(ancorPos.y + i, 0, limitArea.y - 1))
                );
            }


            return result.Distinct().ToList();
        }
    }
}
