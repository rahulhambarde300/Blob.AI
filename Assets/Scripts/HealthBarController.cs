using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthSlider;
    public float sliderSpeed;

    private void Start()
    {
        healthSlider = this.gameObject.GetComponent<Slider>();
        healthSlider.minValue = 0;
    }

    public void setHealth(float health)
    {
        healthSlider = this.gameObject.GetComponent<Slider>();
        healthSlider.value = health;
    }

    public void setMaxHealth(float maxHealth)
    {
        healthSlider = this.gameObject.GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;

    }
}
