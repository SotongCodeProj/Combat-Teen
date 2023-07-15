using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.ActionCreator
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _nonSelectColor;

        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetColor(bool isSelected)
        {
            spriteRenderer.color = isSelected ? _selectedColor : _nonSelectColor;
        }
    }
}
