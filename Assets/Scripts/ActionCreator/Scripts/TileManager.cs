using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CombTeen.ActionCreator
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private ClickableTile[] _availableTile;
        [SerializeField] private ClickableTile _centerTile;
        [SerializeField] private Vector2Int _limitArea;

        private void Start()
        {
            SetTileCoordinate();
        }

        [Button]
        public void SetTileCoordinate()
        {
            int count = 0;
            for (int y = 0; y < _limitArea.y; y++)
            {
                for (int x = 0; x < _limitArea.x; x++)
                {
                    _availableTile[count].SetupCoordinate(new Vector2Int(x, y));
                    count++;
                }
            }

            count = 0;
            var center = _centerTile.Coordinate;

            for (int y = 0; y < _limitArea.y; y++)
            {
                for (int x = 0; x < _limitArea.x; x++)
                {
                    _availableTile[count].SetupCoordinate(
                        _availableTile[count].Coordinate - center
                    );
                    count++;
                }
            }
        }

        public IEnumerable<Vector2Int> GetActiveTileCoordinates()
        {
            List<Vector2Int> result = new List<Vector2Int>();
            foreach (var tile in _availableTile)
            {
                if (tile.IsSelected)
                {
                    result.Add(tile.Coordinate);
                }
            }
            return result;
        }
    }
}
