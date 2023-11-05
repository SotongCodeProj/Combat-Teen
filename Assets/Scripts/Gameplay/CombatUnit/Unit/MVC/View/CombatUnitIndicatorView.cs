using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUnitIndicatorView : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _unitName;

    public void UpdateHealthView(int currentHealth, int maxHealth)
    {
        _healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    public void SetUnitName(string unitName)
    {
        _unitName.text = unitName;
    }
}
