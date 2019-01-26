using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawnPoints;
    public List<bool> spawnUsed;

    public void StartEmery(int number)
    {
        for(int i=0; i<number; i++)
        {
            //da aggiungere controllo su point usati
                int randomIndex = Mathf.RoundToInt(Random.Range(0, spawnPoints.Count));
                if (spawnUsed[randomIndex])
                {

                }
        }


        Instantiate(enemy, spawnPoints[0].transform.position, Quaternion.identity);
        enemy.SetActive(true);
    }
}
