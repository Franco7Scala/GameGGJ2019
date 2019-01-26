using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovementStep = 1f;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * playerMovementStep;
        float v = Input.GetAxis("Vertical") * playerMovementStep;

        Vector3 vel = playerRb.velocity;
        vel.x = h;
        vel.z = v;
        playerRb.velocity = vel;
    }
}
