using System.Threading;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Letter : MonoBehaviour {

    private Vector3 startPosition;
    private NavMeshAgent agent;
    private GameObject player;
    private bool following = false;
    private bool returning = false;


    void Start() {
        startPosition = transform.position;
        player = Support.sharedObjects.player;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.enabled = false;
    }

    void Update() {
        if ( following ) {
            Thread.Sleep(3);
            Follow();
        }
    }

    void OnTriggerEnter(Collider other) {
        if ( other.gameObject == player ) {
            StartFollowing();
        }
    }

    void StartFollowing() {
        returning = false;
        following = true;
        agent.enabled = true;
        Follow();
    }

    void Follow() {
        agent.destination = player.GetComponent<Transform>().position;
    }

    public void Return() {
        returning = true;
        following = false;
        agent.enabled = true;
        agent.destination = startPosition;
    }


}
