using UnityEngine;


public class Support : MonoBehaviour {
    public static Support sharedObjects;
    public GameObject player;
    public float thresholdDistancePlayer = 10.0f;
    public float thresholdDamagePlayer = 1.0f;


    private void Start() {
        sharedObjects = this;
    }


}
