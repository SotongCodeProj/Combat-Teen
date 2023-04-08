using UnityEngine;
using UnityEngine.Events;

namespace CombTeen.Gameplay.Tile.Object
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tileVisual;
        [SerializeField] private ClickableTileControl _clickableControl;

        public UnityEvent OnClickEvent { private set; get; } = new UnityEvent();

        private void Awake() {
            _clickableControl.OnClickEvent.AddListener(()=> OnClickEvent?.Invoke());
        }

        internal void ChangeColor(Color red)
        {
            _tileVisual.color = red;
        }
    }
}
