using System.Threading;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Patrol : MonoBehaviour {
    public Transform[] points;
    public GameObject colliderObject;
    public AudioClip clip;

    private int destinationPoint = 0;
    private bool killed = false;
    private NavMeshAgent agent;
    private Rigidbody body;
    private PlayerHealth playerHealth;
    private Transform playerTransform;


    void Start() {
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
         playerHealth = Support.sharedObjects.player.GetComponent<PlayerHealth>();
        playerTransform = Support.sharedObjects.player.GetComponent<Transform>();
        agent.autoBraking = false;
        if ( points.Length > 0 ) {
            GotoNextPoint();
        }
    }

    void Update() {
        if ( !killed ) {
            if ( Vector3.Distance(GetComponent<Transform>().position, playerTransform.position) <= Support.sharedObjects.thresholdDistancePlayer ) {
                agent.destination = playerTransform.position;
            }
            else if ( !agent.pathPending && agent.remainingDistance < 0.5f ) {
                GotoNextPoint();
            }
        }
    }

    void GotoNextPoint() {
        if (agent.enabled)
        {
            agent.destination = points[destinationPoint].position;
            destinationPoint = (destinationPoint + 1) % points.Length;
        }
    }

    public void Kill() {
        foreach ( Collider c in GetComponents<Collider>() ) {
            c.isTrigger = true;
        }
        Destroy(colliderObject);
        killed = true;
        agent.enabled = false;
        body.isKinematic = false;
        Destroy(gameObject, 3.0f);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject == Support.sharedObjects.player)
        {
            Support.sharedObjects.inventary.GetComponent<InventaryManager>().ClearLetters();
            Support.sharedObjects.controller.GetComponent<AudioSource>().PlayOneShot(clip);

            playerHealth.EnemyAttack(10);
            GotoNextPoint();
#if UNITY_STANDALONE
            Thread.Sleep(5);
#endif
        }
    }




}
