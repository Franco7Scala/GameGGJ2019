using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public Image fitnessBar;
    public float healthDamage = 0.1f;
    public float healthRegenerationStep = 0.1f;

    public void IncreaseHealthLetterCollected()
    {
        healthBar.fillAmount += healthRegenerationStep;
        Support.sharedObjects.player.GetComponent<PlayerHealth>().health = healthBar.fillAmount * 100;
    }

    private void decreaseBar(float damage)
    {
        healthBar.fillAmount -= damage;
    }

    private void Update()
    {
        if (healthBar.fillAmount <= 0 || Support.sharedObjects.player.GetComponent<PlayerHealth>().FOREVER)
        {
            return;
        }

        healthBar.fillAmount -= (healthDamage * Time.deltaTime);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthBar.fillAmount);

        fitnessBar.fillAmount = Support.sharedObjects.player.GetComponent<PlayerHealth>().fitness / Support.sharedObjects.player.GetComponent<PlayerHealth>().maxFitness;

        Support.sharedObjects.player.GetComponent<PlayerHealth>().health = healthBar.fillAmount * 100;
    }
}
