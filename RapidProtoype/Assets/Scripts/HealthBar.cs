using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        // Set the maximum value of the slider to the provided health value.
        slider.maxValue = health;
        // Set the current value of the slider to match the maximum health value initially.
        slider.value = health;
        // Set the color of the health bar fill to the color corresponding to a value of 1 in the gradient.
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        // Update the slider's value to match the current health value.
        slider.value = health;
        // Set the color of the health bar fill based on the normalized value of the slider.
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
