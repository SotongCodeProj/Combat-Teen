using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CombTeen.ActionCreator
{
    public class ClickableTile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TileView _view;

        public Vector2Int Coordinate { private set; get; }
        public bool IsSelected { private set; get; }

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickAction();
        }

        public void SetupCoordinate(Vector2Int coordinate)
        {
            Coordinate = coordinate;
        }

        private void ClickAction()
        {
            IsSelected = !IsSelected;
            _view.SetColor(IsSelected);
        }
    }
}
