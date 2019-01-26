using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Image healthBar;
    public float healthDamage = 0.1f;

    private void decreaseBar(float damage)
    {
        healthBar.fillAmount -= damage;
    }

    private void Update()
    {
        if (healthBar.fillAmount <= 0)
        {
            return;
        }

        healthBar.fillAmount -= (healthDamage * Time.deltaTime);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthBar.fillAmount);
    }
}
