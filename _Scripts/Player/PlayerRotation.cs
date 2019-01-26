using UnityEngine;


public class PlayerRotation : MonoBehaviour {
    public float rotationStep = 0.15f;


    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 NextDir = new Vector3(-h, 0, -v);
        if ( NextDir != Vector3.zero ) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(NextDir), rotationStep);
        }
    }


}
