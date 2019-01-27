using System.Collections;
using UnityEngine;


public class PlayerHealth : MonoBehaviour {
    public float health = 100f;
    public float fitness = 100f;

    public float secToIncrease = 0.1f;
    public float secToDecrease = 0.2f;

    private bool continueIncrease = false;
    private bool continueDecrease = false;

    public void EnemyAttack(float quantity) {
        if( health <= 0) {
            return;
        }

        health -= quantity;
        if(health <= 0)
        {
            GetComponent<Animator>().SetBool("Damage", true);
            GetComponent<Animator>().SetBool("Die", true);
        }
    }

    public void IncreaseFitness() {
        continueDecrease = false;
        continueIncrease = true;

        StopCoroutine(DecreaseCoroutine());
        StartCoroutine(IncreaseCoroutine());
    }

    public void DecreaseFitness() {
        continueDecrease = false;
        continueIncrease = true;

        StopCoroutine(IncreaseCoroutine());
        StartCoroutine(DecreaseCoroutine());
    }

    public bool FitnessAvailable() {
        return true;
    }

    IEnumerator IncreaseCoroutine()
    {
        while(continueIncrease)
        {
            fitness += secToIncrease * 100f;
            if(fitness >= 100f)
            {
                fitness = 100f;
                continueIncrease = false;
            }
            yield return new WaitForSeconds(secToIncrease);
        }
    }

    IEnumerator DecreaseCoroutine()
    {
        while (continueDecrease)
        {
            fitness -= secToDecrease * 100f;
            if (fitness <= 0f)
            {
                fitness = 0f;
                continueDecrease = false;
            }
            yield return new WaitForSeconds(secToDecrease);
        }
    }
}
