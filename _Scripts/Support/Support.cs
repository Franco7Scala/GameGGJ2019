using UnityEngine;


public class Support : MonoBehaviour {
    public static Support sharedObjects;
    public GameObject player;
    public GameObject controller;
    public GameObject inventary;
    public float thresholdDistancePlayer = 15.0f;
    public float thresholdDamagePlayer = 1.0f;


    private void Awake() {
        sharedObjects = this;
    }


}
