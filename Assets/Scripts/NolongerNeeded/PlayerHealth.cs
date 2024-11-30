using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField]private int currentHealth;
    [SerializeField]private int maxHealth;
    [SerializeField]private HealthBarUI healthBarUI;

    private void Awake()
    {
        instance = this;
        if (healthBarUI == null)
        {
            healthBarUI = FindObjectOfType<HealthBarUI>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarUI.SetHealthBar(currentHealth, maxHealth);
    }

    public void DamageHealth(int damage)
    {
        currentHealth -= damage;
        healthBarUI.SetHealthBar(currentHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
