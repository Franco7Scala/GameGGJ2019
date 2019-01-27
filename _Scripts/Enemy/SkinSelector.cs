using UnityEngine;


public class SkinSelector : MonoBehaviour {
    public GameObject[] skins;

    void Start() {
        int randomIndex = Mathf.RoundToInt(Random.Range(0, skins.Length));
        skins[randomIndex].SetActive(true);
    }
}
