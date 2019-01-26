using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(Health))]
//[RequireComponent(typeof(Attacker))]
//[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 50f;

    //public VirtualPad pad;
    public float walkSpeed = 6.0f;
    public float runSpeed = 13.0f;
    public float gravity = -9.8f;
    public int maxJumpSteps = 6;

    private CharacterController controller;
    //private Health health;
    //private PlayerAnimator playerAnimator;
    //private Attacker attacker;
    private int jumpSteps = Int32.MaxValue;
    private bool running = false;
    private float speed = 0;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        //health = GetComponent<Health>();
        //attacker = GetComponent<Attacker>();
        //playerAnimator = GetComponent<PlayerAnimator>();
        speed = walkSpeed;
    }

    void Update()
    {
        // Movement
        float h = -Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(0, 0, (pad.Vertical() * speed));
        Vector3 movement = new Vector3(h * speed, 0, v * speed);
        movement = Vector3.ClampMagnitude(movement, speed);
        // Jump
        if (jumpSteps < maxJumpSteps)
        {
            jumpSteps++;
            movement.y = -gravity;
        }
        else
        {
            movement.y = gravity;
        }
        // Run
        Run();

        // Finalizing
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }

    public void Jump()
    {
        jumpSteps = 0;
    }

    public void StartRun()
    {
        running = true;
        //health.DecreaseFitness();
    }

    public void StopRun()
    {
        running = false;
        //health.IncreaseFitness();
    }

    public void Attack()
    {
        //playerAnimator.AnimateArm();
        //attacker.Hurt();
    }

    private void Run()
    {
        if (running /*&& health.fitnessAvailable()*/)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
            //health.IncreaseFitness();
        }
    }
}
