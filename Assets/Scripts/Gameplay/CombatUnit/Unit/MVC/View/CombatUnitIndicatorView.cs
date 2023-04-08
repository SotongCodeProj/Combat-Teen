using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUnitIndicatorView : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    public void UpdateHealthView(int currentHealth, int maxHealth)
    {
        _healthBar.fillAmount = (float) currentHealth / maxHealth;
    }
}
