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
}
