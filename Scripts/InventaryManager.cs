using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventaryManager : MonoBehaviour
{
    private char[] letters;
    private bool[] found;
    private Text[] textareas;
    private GameObject[] listLetterObject;
    private List<Letter> listLetterCollected;

    private LevelManager levelManager;
    public AudioClip clip;
    public GameObject[] alphabet;

    public GameObject gridLayout;
    public GameObject letterUi;
    public GameObject levelObject;

    private int indexLetter = 0;

    public int IndexLetter
    {
        get
        {
            return indexLetter;
        }
        set
        {
            indexLetter = value;
        }
    }

    public void Init(string word, GameObject[] spawnPoints, Vector3 playerPosition)
    {
        levelManager = levelObject.GetComponent<LevelManager>();
        listLetterCollected = new List<Letter>();

        letters = word.ToUpper().ToCharArray();
        found = new bool[letters.Length];
        textareas = new Text[letters.Length];
        listLetterObject = new GameObject[letters.Length];

        bool[] spawnPointUsed = new bool[spawnPoints.Length];

        for (int i=0; i<letters.Length; i++)
        {
            GameObject obj = Instantiate(letterUi, new Vector3(0, 0, 0), Quaternion.identity);
            textareas[i] = obj.GetComponent<Text>();

            obj.SetActive(true);
            obj.transform.parent = gridLayout.transform;

            textareas[i].text = letters[i].ToString();
            textareas[i].color = new Color(0.8773585f, 0.864943f, 0.864943f, 1f);


            byte[] asciChar = Encoding.ASCII.GetBytes(letters[i].ToString());
            int position = asciChar[0] - 65;

            listLetterObject[i] = Instantiate(alphabet[position], new Vector3(0, 0, 0), Quaternion.identity);

            while (true)
            {
                if (i == 0)
                {
                    Vector3 nearPosition = playerPosition + new Vector3(5, 0, 0);
                    listLetterObject[i].transform.position = nearPosition;
                    listLetterObject[i].SetActive(true);
                    break;
                }
                else
                {
                    int randomIndex = Mathf.RoundToInt(Random.Range(0, spawnPoints.Length));
                    if (!spawnPointUsed[randomIndex])
                    {
                        spawnPointUsed[randomIndex] = true;

                        try
                        {
                            listLetterObject[i].transform.position = spawnPoints[randomIndex].transform.position;
                            listLetterObject[i].SetActive(true);
                        }catch(System.Exception _)
                        {}


                        break;
                    }
                }
            }
        }
    }

    public Letter GetGameObjectBefore(Letter letter)
    {
        for (int i=0; i<listLetterCollected.Count; i++)
        {
            if(listLetterCollected[i].id == letter.id)
            {
                if (i == 0)
                {
                    return null;
                }
                else
                {
                    return listLetterCollected[i - 1];
                }
            }
        }
        return null;
    }

    public bool AddLetter(char letter, Letter letterCoolected)
    {
        listLetterCollected.Add(letterCoolected);
        levelManager.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == letter && !found[i])
            {
                found[i] = true;

                textareas[i].color = new Color(0.9716981f, 0.6558038f, 0.1420879f, 1f);

                bool win = checkWin();

                if (win)
                {
                    levelManager.Win();
                }

                return win;
            }
        }
        return false;
    }

    public void ClearLetters()
    {
        for(int i=0; i<found.Length; i++)
        {
            found[i] = false;
            textareas[i].color = new Color(0.8773585f, 0.864943f, 0.864943f, 1f);
        }

        foreach(Letter l in listLetterCollected)
        {
            l.Return();
        }

        listLetterCollected.Clear();
    }

    public bool checkWin()
    {
        foreach(bool status in found)
        {
            if (!status)
            {
                return false;
            }
        }
        return true;
    }
}
