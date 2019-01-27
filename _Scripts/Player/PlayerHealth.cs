using System.Collections;
using UnityEngine;


public class PlayerHealth : MonoBehaviour {
    public float health = 100f;
    public float fitness = 10f;
    public float maxFitness = 10f;
    public float decreaseFitnessRate = 1.0f;
    public float increaseFitnessRate = 2.0f;
    private bool increasingFitness = false;
    private bool decreasingFitness = false;

    public bool FOREVER = false;

    private void Update()
    {
        if(FOREVER)
        {
            return;
        }

        if(health <= 0)
        {
            GetComponent<PlayerMovement>().Die();
            return;
        }
        if (increasingFitness)
        {
            fitness += Time.deltaTime / increaseFitnessRate;
            if (fitness >= maxFitness)
            {
                fitness = maxFitness;
                increasingFitness = false;
            }
        }
        if (decreasingFitness)
        {
            fitness -= Time.deltaTime / decreaseFitnessRate;
            if (fitness <= 0)
            {
                fitness = 0;
                decreasingFitness = false;
            }
        }
    }

    public void EnemyAttack(float quantity) {
        if( health <= 0) {
            return;
        }

        health -= quantity;
        if(health <= 0) {
            GetComponent<PlayerMovement>().Die();
        }
        else {
            GetComponent<PlayerMovement>().Damage();
        }

    }

    public void IncreaseFitness() {
        decreasingFitness = false;
        increasingFitness = true;
    }

    public void DecreaseFitness() {
        decreasingFitness = true;
        increasingFitness = false;
    }

    public bool FitnessAvailable() {
        return fitness > 0;
    }

}
