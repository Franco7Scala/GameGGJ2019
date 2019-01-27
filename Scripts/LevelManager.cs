using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject manager;

    private GameObject[] spawnPoints;
    private SpawnManager spawnManager;
    private MainLightManager lightManager;
    private List<string> words;

    void Start()
    {
        words = new List<string>();
        words.Add("t");
        words.Add("test2");
        words.Add("test3");
        words.Add("test4");
        words.Add("test5");

        int level = PlayerPrefs.HasKey("level") ? PlayerPrefs.GetInt("level") : 1;

        lightManager = manager.GetComponent<MainLightManager>();
        lightManager.IntensityUp(((float)level) / ((float)words.Count));

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsPlayer");

        spawnManager = manager.GetComponent<SpawnManager>();
        spawnManager.InitScene(spawnPoints, words[level-1]);
    }

    public void Win()
    {
        int level = PlayerPrefs.HasKey("level") ? PlayerPrefs.GetInt("level") : 1;
        PlayerPrefs.SetInt("level", level + 1);
    }
}
