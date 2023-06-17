
using TMPro;
using UnityEngine;

public class CombatCanvasView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitName;

    public void SetName(string unitName)
    {
        _unitName.text = unitName;
    }
}
