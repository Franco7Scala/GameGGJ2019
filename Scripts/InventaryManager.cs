using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{
    public char[] letters;
    public bool[] found;


    public void Init(string word)
    {
        letters = word.ToCharArray();
        found = new bool[letters.Length];
    }


    public bool AddLetter(char letter)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == letter && !found[i])
            {
                found[i] = true;

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
