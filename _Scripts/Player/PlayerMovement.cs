using System;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour {
    public GameObject[] skins;
    public AudioSource singleAudioSource;
    public AudioClip walkClip;
    public AudioClip walkOnWaterClip;
    public AudioClip runClip;
    public AudioClip jumpClip;
    public float turnSpeed = 50f;
    public float walkSpeed = 6.0f;
    public float runSpeed = 13.0f;
    public float terminalVelocity = -10.0f;
    public float minimumFall = -1.5f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15.0f;

    private CharacterController controller;
    private PlayerHealth health;
    private AudioSource audioSource;
    private ControllerColliderHit contact;
    private Animator animator;
    private int jumpSteps = Int32.MaxValue;
    private float speed = 0;
    private bool running = false;
    private bool jumping = false;
    private bool onWater = false;
    private float verticalSpeed = 0;


    void Start() {
        controller = GetComponent<CharacterController>();
        health = GetComponent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
        speed = walkSpeed;
        int skin = PlayerPrefs.GetInt("skin", 0);
        skins[0].SetActive(true);
        animator = skins[0].GetComponent<Animator>();
    }

    void Update() {
        // Movement
        float h = -Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        // Jump
        if ( Input.GetKeyDown(KeyCode.Space) && !jumping ) {
            jumping = true;
            verticalSpeed = jumpSpeed;
            singleAudioSource.PlayOneShot(jumpClip, 1.0f);
            animator.SetTrigger("Jump");
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
            if ( audioSource.clip != runClip ) {
                audioSource.clip = runClip;
            }
            if ( !audioSource.isPlaying ) {
                audioSource.Play();
            }
            animator.SetBool("Walk", false);
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else if ( h == 0.0f && v == 0.0f ) {
            audioSource.Pause();
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
        else {
            if ( onWater ) {
                if ( audioSource.clip != walkOnWaterClip ) {
                    audioSource.clip = walkOnWaterClip;
                }
                if ( !audioSource.isPlaying ) {
                    audioSource.Play();
                }
            }
            else {
                if ( audioSource.clip != walkClip ) {
                    audioSource.clip = walkClip;
                }
                if ( !audioSource.isPlaying ) {
                    audioSource.Play();
                }

            }
            animator.SetBool("Walk", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            speed = walkSpeed;
            health.IncreaseFitness();
        }
        Vector3 movement = new Vector3(h * speed, 0, v * speed);
        movement = Vector3.ClampMagnitude(movement, speed);
        // Jump
        if ( IsRayGrounded() ) {
            jumping = false;
            verticalSpeed = minimumFall;
        }
        else {
            verticalSpeed += gravity * 5 * Time.deltaTime;
            if ( verticalSpeed < terminalVelocity ) {
                verticalSpeed = terminalVelocity;
            }
            if ( controller.isGrounded ) {
                if ( Vector3.Dot(movement, contact.normal) < 0 ) {
                    movement -= contact.normal * speed;
                }
                else {
                    movement += contact.normal * speed;
                }
            }
        }
        movement.y = verticalSpeed;
        // Finalizing
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }

    private bool IsRayGrounded() {
        RaycastHit hit;
        if ( verticalSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit) ) {
            float check = (controller.height + controller.radius) / 2.0f;
            return (hit.distance <= check);
        }
        return false;
    }

    public void SetOnWater(bool status) {
        onWater = status;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        contact = hit;
    }


}
