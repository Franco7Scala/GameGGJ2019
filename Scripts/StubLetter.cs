using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubLetter : MonoBehaviour
{
    public GameObject inventaryManager;

    void Start()
    {
        inventaryManager.GetComponent<InventaryManager>().Init("test".ToUpper());

        StartCoroutine(test());
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(2);

        inventaryManager.GetComponent<InventaryManager>().AddLetter('T');
    }
}
