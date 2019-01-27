using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject manager;
    public GameObject house;
    public GameObject end;

    private GameObject[] spawnPoints;
    private GameObject[] enemyObject;
    private SpawnManager spawnManager;
    private MainLightManager lightManager;
    private List<string> words;
    private List<int> enemy;

    void Start()
    {
        words = new List<string>();
        words.Add("B");
        //words.Add("Support");
        //words.Add("Serenity");
        //words.Add("familiarity");

        enemy = new List<int>();
        enemy.Add(3);
        //enemy.Add(6);
        //enemy.Add(9);
        //enemy.Add(12);

        int level = PlayerPrefs.GetInt("level", 1);

        lightManager = manager.GetComponent<MainLightManager>();
        lightManager.IntensityUp((((float)level) / ((float)words.Count)) * 0.5f);

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsPlayer");
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyObject.Length > 0)
        {
            foreach(GameObject go in enemyObject)
            {
                go.SetActive(false);
            }
            int enemyToShow = enemy[level - 1];
            List<int> indexUsed = new List<int>();
            while (true)
            {
                int randomIndex = Mathf.RoundToInt(Random.Range(0, enemyObject.Length));
                if (!indexUsed.Contains(randomIndex))
                {
                    indexUsed.Add(randomIndex);
                    enemyObject[randomIndex].SetActive(true);
                }

                if (indexUsed.Count == enemyToShow)
                {
                    break;
                }
            }
        }

        spawnManager = manager.GetComponent<SpawnManager>();
        spawnManager.InitScene(spawnPoints, words[level-1]);
    }


    //private void Update() {
    //     if ( Input.GetKeyDown(KeyCode.O) ) {
    //        house.SetActive(true);
    //        house.GetComponent<Rigidbody>().isKinematic = false;
    //        Vector3 pos = Support.sharedObjects.player.transform.position;
    //        pos.y += 10;
    //        pos.z -= 4;
    //        pos.x -= 4;
    //        house.transform.position = pos;
    //        Support.sharedObjects.player.GetComponent<PlayerParty>().AnimateCompletion(AfterEnd);
    //    }
    //}
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

            end.SetActive(true);

            house.SetActive(true);
            house.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = Support.sharedObjects.player.transform.position;
            pos.y += 10;
            pos.z -= 4;
            pos.x -= 4;
            house.transform.position = pos;
            Support.sharedObjects.player.GetComponent<PlayerParty>().AnimateCompletion(AfterEnd);

            PlayerPrefs.DeleteAll();
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
