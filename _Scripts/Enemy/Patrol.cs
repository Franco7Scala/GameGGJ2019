using System.Threading;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour {
    public Transform[] points;

    private int destinationPoint = 0;
    private bool killed = false;
    private NavMeshAgent agent;
    //private PlayerHealth playerHealth;
    private Transform playerTransform;


    void Start() {
        agent = GetComponent<NavMeshAgent>();
       // playerHealth = Support.sharedObjects.player.GetComponent<PlayerHealth>();
        playerTransform = Support.sharedObjects.player.GetComponent<Transform>();
        agent.autoBraking = false;
        if ( points.Length > 0 ) {
            GotoNextPoint();
        }
    }

    void Update() {
        if ( !killed ) {
            if ( Vector3.Distance(GetComponent<Transform>().position, playerTransform.position) <= Support.sharedObjects.thresholdDamagePlayer ) {
                // playerHealth.MakeDamage();
                GotoNextPoint();
                Thread.Sleep(10);
            }
            else if ( Vector3.Distance(GetComponent<Transform>().position, playerTransform.position) <= Support.sharedObjects.thresholdDistancePlayer ) {
                agent.destination = playerTransform.position;
            }
            else if ( !agent.pathPending && agent.remainingDistance < 0.5f ) {
                GotoNextPoint();
            }
        }
    }

    void GotoNextPoint() {
        agent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    } 

    public void OnTriggerEnter(Collider other) {
        if ( other.gameObject == Support.sharedObjects.player ) {
            killed = true;
        }
    }


}