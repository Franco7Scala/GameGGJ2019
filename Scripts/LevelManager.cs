using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject manager;
    public GameObject house;

    private GameObject[] spawnPoints;
    private SpawnManager spawnManager;
    private MainLightManager lightManager;
    private List<string> words;

    void Start()
    {
        words = new List<string>();
        words.Add("t");
        words.Add("testsdsd");
        words.Add("test3");
        words.Add("test4");
        words.Add("test5");

        int level = PlayerPrefs.GetInt("level", 1);

        lightManager = manager.GetComponent<MainLightManager>();
        lightManager.IntensityUp(((float)level) / ((float)words.Count));

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsPlayer");

        spawnManager = manager.GetComponent<SpawnManager>();
        spawnManager.InitScene(spawnPoints, words[level-1]);
    }


    private void Update() {
         if ( Input.GetKeyDown(KeyCode.O) ) {
            house.SetActive(true);
            house.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = Support.sharedObjects.player.transform.position;
            pos.y += 7;
            pos.z -= 4;
            pos.x -= 4;
            house.transform.position = pos;
            Support.sharedObjects.player.GetComponent<PlayerParty>().AnimateCompletion(AfterEnd);
        }
    }
    public void Win()
    {
        int level = PlayerPrefs.GetInt("level", 1);
        PlayerPrefs.SetInt("level", level + 1);



        if (level != words.Count)
        {
            Support.sharedObjects.player.GetComponent<PlayerParty>().AnimateCompletion(AfterWin);
        }
        else
        {
            house.SetActive(true);
            house.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = Support.sharedObjects.player.transform.position;
            pos.y += 7;
            pos.z -= 4;
            pos.x -= 4;
            house.transform.position = pos;
            Support.sharedObjects.player.GetComponent<PlayerParty>().AnimateCompletion(AfterEnd);
        }
    }

    public void AfterWin ()
    {
        GetComponent<GameController>().ReloadScene();
    }

    public void AfterEnd()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
