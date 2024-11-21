using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]private Slider healthBar;

    
    public void SetHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.value = (float)currentHealth / maxHealth;
    }
}
