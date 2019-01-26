using UnityEngine;


public class SkinSelector : MonoBehaviour {
    public GameObject[] skins;

        
    void Start() {
        skins[Random.Range(0, skins.Length - 1)].SetActive(true);
    }


}
