using System;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerMovement : MonoBehaviour {
    public float turnSpeed = 50f;
    public float walkSpeed = 6.0f;
    public float runSpeed = 13.0f;
    public float gravity = -9.8f;
    public int maxJumpSteps = 6;

    private CharacterController controller;
    private PlayerHealth health;
    private int jumpSteps = Int32.MaxValue;
    private float speed = 0;
    private bool running = false;


    void Start() {
        controller = GetComponent<CharacterController>();
        health = GetComponent<PlayerHealth>();
        speed = walkSpeed;
    }

    void Update() {
        // Movement
        float h = -Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        // Jump
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            jumpSteps = 0;
        }
        if ( Input.GetKeyDown(KeyCode.LeftShift) ) {
            running = true;
            health.DecreaseFitness();
        }
        else if ( Input.GetKeyUp(KeyCode.LeftShift) ) {
            running = false;
        }
        // Running
        if ( running && health.FitnessAvailable() ) {
            speed = runSpeed;
        }
        else {
            speed = walkSpeed;
            health.IncreaseFitness();
        }
        Vector3 movement = new Vector3(h * speed, 0, v * speed);
        movement = Vector3.ClampMagnitude(movement, speed);
        // Jump
        if ( jumpSteps < maxJumpSteps ) {
            jumpSteps++;
            movement.y = -gravity;
        }
        else {
            movement.y = gravity;
        }
        // Finalizing
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }


}
