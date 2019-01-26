using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPlayer : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject Player;

    public void StartPlayer()
    {
        int randomIndex = Mathf.RoundToInt(Random.Range(0, spawnPoints.Count));

        GameObject point = spawnPoints[randomIndex];

        Player.transform.position = point.transform.position;
    }
}
