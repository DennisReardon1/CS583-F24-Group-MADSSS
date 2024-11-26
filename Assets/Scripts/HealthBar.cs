using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Slider healthSlider34;

    private void Start(){
        healthSlider34 = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    public void SetMaxHealth(int MaxyHealth)
    {
        healthSlider34.maxValue = MaxyHealth;
        healthSlider34.value = MaxyHealth;
    }


    public void SetHealth(int Health)
    {
        healthSlider34.value = Health;
    }
}
