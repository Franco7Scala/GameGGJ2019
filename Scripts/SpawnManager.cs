using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerManager;
    //public GameObject emeryManager;

    void Start()
    {
        RandomSpawnPlayer randomSpawnPlayer = playerManager.GetComponent<RandomSpawnPlayer>();
        //RandomSpawnEnemy randomSpawnEmery = emeryManager.GetComponent<RandomSpawnEnemy>();

        randomSpawnPlayer.StartPlayer();
        //randomSpawnEmery.StartEmery(1);
    }
}
