using System.Threading;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Letter : MonoBehaviour {

    private InventaryManager inventaryManager;
    public GameObject inventaryObject;
    public float rotationSpeed = 100;

    private Vector3 startPosition;
    private NavMeshAgent agent;
    private GameObject player;
    private bool following = false;
    private bool returning = false;

    public int id;

    void Start() {
        inventaryManager = inventaryObject.GetComponent<InventaryManager>();
        id = inventaryManager.IndexLetter;
        inventaryManager.IndexLetter = id + 1;

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
        else
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other) {
         if ( other.gameObject == player ) {
             if (!following)
            {
                if (agent.name.Contains("(Clone)"))
                {
                    bool win = inventaryManager.AddLetter(agent.name[0], this);
                    Debug.Log(win);
                }
                Debug.Log(other.gameObject.name);
                //inventaryManager.AddLetter()
            }
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
        Letter po = inventaryManager.GetGameObjectBefore(this);
        Vector3 destination;
        if (po == null)
        {
            destination = player.GetComponent<Transform>().position;
            destination -= player.GetComponent<Transform>().forward * 3;
        }
        else
        {
            destination = po.transform.position;
            destination -= player.GetComponent<Transform>().forward ;
        }


        agent.destination = destination;
        agent.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void Return() {
        returning = true;
        following = false;
        agent.enabled = true;
        agent.destination = startPosition;
        agent.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
    }


}
