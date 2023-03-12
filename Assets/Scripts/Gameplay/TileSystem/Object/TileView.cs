using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Tile.Object
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tileVisual;

        internal void ChangeColor(Color red)
        {
            _tileVisual.color = red;
        }
    }
}
