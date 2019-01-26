using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    
    public void EnemyAttack(float quantity)
    {
        if( health <= 0)
        {
            return;
        }

        health -= quantity;
    }


}
