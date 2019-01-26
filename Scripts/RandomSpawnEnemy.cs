using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    public List<GameObject> spawnPoints;

    public void StartEmery(int number)
    {
        /*
        int randomIndex = Mathf.RoundToInt(Random.Range(0, spawnPoints.Count));

        GameObject point = spawnPoints[randomIndex];

        Player.transform.position = point.transform.position;
        */

        GameObject go = (GameObject)Instantiate(Resources.Load("Cylinder"));
        int a = 0;
    }
}
