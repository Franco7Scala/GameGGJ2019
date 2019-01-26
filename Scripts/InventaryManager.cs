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

    public GameObject[] alphabet;

    public GameObject gridLayout;
    public GameObject letterUi;

    public void Init(string word, GameObject[] spawnPoints, Vector3 playerPosition)
    {
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
                    listLetterObject[i].transform.Rotate(new Vector3(90, 0, 0), Space.World);
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
                            listLetterObject[i].transform.Rotate(new Vector3(90, 0, 0), Space.World);
                            listLetterObject[i].SetActive(true);
                        }catch(System.Exception _)
                        {}


                        break;
                    }
                }
            }
        }
    }


    public bool AddLetter(char letter)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == letter && !found[i])
            {
                found[i] = true;

                textareas[i].color = new Color(0.9716981f, 0.6558038f, 0.1420879f, 1f);

                return checkWin();
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
