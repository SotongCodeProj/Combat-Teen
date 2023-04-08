using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableTileControl : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnClickEvent { private set; get; } = new UnityEvent();
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke();
    }
}
