using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject manager;

    private GameObject[] spawnPoints;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsPlayer");

        spawnManager = manager.GetComponent<SpawnManager>();
        spawnManager.InitScene(spawnPoints, "test");
    }
}
