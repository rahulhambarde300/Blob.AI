using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarController : MonoBehaviour
{
    private Slider powerSlider;
    public float sliderSpeed;

    private void Start()
    {
        powerSlider = this.gameObject.GetComponent<Slider>();
        powerSlider.minValue = 0;
    }

    public void setPower(float health)
    {
        powerSlider = this.gameObject.GetComponent<Slider>();
        powerSlider.value = health;
    }

    public void setMaxPower(float maxHealth)
    {
        powerSlider = this.gameObject.GetComponent<Slider>();
        powerSlider.maxValue = maxHealth;

    }
}
