using UnityEngine;


public class PlayerHealth : MonoBehaviour {
    public float health = 100f;


    public void EnemyAttack(float quantity) {
        if( health <= 0) {
            return;
        }
        health -= quantity;
    }

    public void IncreaseFitness() {

    }

    public void DecreaseFitness() {

    }

    public bool FitnessAvailable() {
        return true;
    }


}
