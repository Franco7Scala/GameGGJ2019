using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    public Material transparentMat;

    private GameObject prevCollided;
    private Material prevMaterial;

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if(hit.collider.CompareTag("Building") || hit.collider.CompareTag("Untagged"))
            {
                if(prevCollided != null)
                {
                    prevCollided.GetComponent<Renderer>().material = prevMaterial;
                }
                prevCollided = hit.collider.gameObject;
                prevMaterial = prevCollided.GetComponent<Renderer>().material;

                hit.collider.GetComponent<Renderer>().material = transparentMat;
            } else if(hit.collider.CompareTag("Player") && prevCollided != null)
            {
                prevCollided.GetComponent<Renderer>().material = prevMaterial;
            }
        }
    }
}
