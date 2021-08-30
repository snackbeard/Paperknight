using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Slider slider;
    
    public void takeDamage(int damage)
    {
        slider.value -= damage;
    }

    public void moveToPosition(Vector3 position)
    {
        this.slider.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    public void setMaxHealth(int maxHealth)
    {
        this.slider.maxValue = maxHealth;
        this.slider.value = maxHealth;
    }
}
