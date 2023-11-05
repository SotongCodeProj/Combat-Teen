using System.Collections.Generic;
using UnityEngine;
namespace CombTeen.Gameplay.Tile.Helper
{
    public class TileSystemHelper
    {
        public static IEnumerable<Vector2Int> CalculateTilePosition(Vector2Int ancorPos, IEnumerable<Vector2Int> area, Vector2Int limitArea, bool reverse = false)
        {
            var result = new List<Vector2Int>();
            foreach (var coor in area)
            {
                var xCoor = Mathf.Clamp(ancorPos.x + (reverse ? -coor.x : coor.x), 0, limitArea.x - 1);
                var yCoor = Mathf.Clamp(ancorPos.y + coor.x, 0, limitArea.y - 1);

                Debug.Log($"Ancor :{ancorPos} |Input X{coor.x} Y{coor.y} | Final X{xCoor} Y{yCoor}");
                result.Add(new Vector2Int(Mathf.Clamp(ancorPos.x + (reverse ? -coor.x : coor.x), 0, limitArea.x - 1),
                                          Mathf.Clamp(ancorPos.y + coor.y, 0, limitArea.y - 1)));
            }

            return result;
        }
    }
}
