using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Tile
{    
    public class TileArea
    {
        public TileArea(IEnumerable<Vector2Int> basicArea)
        {
            BasicArea = basicArea;
        }
        #region  Delete Later
        public int Up { set; get; }
        public int Down { set; get; }
        public int Left { set; get; }
        public int Right { set; get; }


        public int UpRight { set; get; }
        public int UpLeft { set; get; }
        public int DownRight { set; get; }
        public int DownLeft { set; get; }
        #endregion

        public IEnumerable<Vector2Int> BasicArea { private set; get; }
        

    }
}