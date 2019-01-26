using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryManager : MonoBehaviour
{
    public char[] letters;
    public bool[] found;
    public Text[] textareas;

    public GameObject gridLayout;
    public GameObject letterUi;

    public void Init(string word)
    {
        letters = word.ToCharArray();
        found = new bool[letters.Length];
        textareas = new Text[letters.Length];

        for(int i=0; i<letters.Length; i++)
        {
            GameObject obj = Instantiate(letterUi, new Vector3(0, 0, 0), Quaternion.identity);
            textareas[i] = obj.GetComponent<Text>();

            obj.SetActive(true);
            obj.transform.parent = gridLayout.transform;

            textareas[i].text = letters[i].ToString();
            textareas[i].color = new Color(0.8773585f, 0.864943f, 0.864943f, 1f);
        }
    }


    public bool AddLetter(char letter)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == letter && !found[i])
            {
                found[i] = true;
                textareas[i].color = Color.green;

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
