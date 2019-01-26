using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectSpawn;
    public GameObject objectInventary;

    public void InitScene(GameObject[] spawnPoints, string word)
    {
        RandomSpawnPlayer randomSpawnPlayer = objectSpawn.GetComponent<RandomSpawnPlayer>();

        int indexPointPlayer = randomSpawnPlayer.StartPlayer(spawnPoints);

        GameObject[] otherSpawnPoints = new GameObject[spawnPoints.Length];
        for(int i=0; i<indexPointPlayer; i++)
        {
            otherSpawnPoints[i] = spawnPoints[i];
        }

        for (int i = indexPointPlayer + 1; i < spawnPoints.Length; i++)
        {
            otherSpawnPoints[i-1] = spawnPoints[i];
        }


        InventaryManager inventaryManager = objectInventary.GetComponent<InventaryManager>();
        inventaryManager.Init(word, otherSpawnPoints, spawnPoints[indexPointPlayer].transform.position);

        //TODO spawn word
    }
}
