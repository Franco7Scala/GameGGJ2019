using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class UserWordController : MonoBehaviour
{
    Regex re = new Regex("/^([a-z]+)$/");

    public string[] feelingWordsList;

    public int numLevels = 3;

    public bool CheckWord(string typedWord)
    {
        return re.IsMatch(typedWord.Trim().ToLower());
    }
}