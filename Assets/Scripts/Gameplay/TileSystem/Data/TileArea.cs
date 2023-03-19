namespace CombTeen.Gameplay.Tile
{
    public interface ITileArea
    {
        public int Up { set; get; }
        public int Down { set; get; }
        public int Left { set; get; }
        public int Right { set; get; }

        public int UpRight { get; }
        public int UpLeft { get; }
        public int DownRight { get; }
        public int DownLeft { get; }
    }

    public class TileArea : ITileArea
    {
        public int Up { set; get; }
        public int Down { set; get; }
        public int Left { set; get; }
        public int Right { set; get; }


        public int UpRight { set; get; }
        public int UpLeft { set; get; }
        public int DownRight { set; get; }
        public int DownLeft { set; get; }
    }
}