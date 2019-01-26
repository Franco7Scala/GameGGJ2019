using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPlayer : MonoBehaviour
{
    public GameObject Player;

    public int StartPlayer(GameObject[] spawnPoints)
    {
        int randomIndex = Mathf.RoundToInt(Random.Range(0, spawnPoints.Length));

        Player.transform.position = spawnPoints[randomIndex].transform.position;

        return randomIndex;
    }
}
