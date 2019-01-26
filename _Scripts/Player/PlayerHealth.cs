using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f;

    public float Health { get => health; set => health = value; }

    public void EnemyAttack(float quantity)
    {
        if(Health <= 0)
        {
            return;
        }

        Health -= quantity;
    }


}
