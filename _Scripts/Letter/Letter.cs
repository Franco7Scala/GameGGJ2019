using System.Threading;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Letter : MonoBehaviour
{

    private InventaryManager inventaryManager;
    public GameObject inventaryObject;
    public float rotationSpeed = 100;

    private Vector3 startPosition;
    private NavMeshAgent agent;
    private GameObject player;
    private bool following = false;
    private bool returning = false;

    public int id;

    void Start()
    {
        inventaryManager = inventaryObject.GetComponent<InventaryManager>();
        id = inventaryManager.IndexLetter;
        inventaryManager.IndexLetter = id + 1;

        startPosition = transform.position;
        player = Support.sharedObjects.player;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.enabled = false;
    }

    void Update()
    {
        if (following)
        {
            Thread.Sleep(3);
            Follow();
        }
        else
        {
            transform.GetChild(1).transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.enabled = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (!following)
            {
                if (agent.name.Contains("(Clone)"))
                {
                    bool win = inventaryManager.AddLetter(agent.name[0], this);
                    transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
                    Support.sharedObjects.controller.GetComponent<HealthManager>().IncreaseHealthLetterCollected();

                    Debug.Log(win);
                }
                Debug.Log(other.gameObject.name);
            }
            StartFollowing();
        }
    }

    void StartFollowing()
    {
        returning = false;
        following = true;
        agent.enabled = true;
        Follow();
    }

    void Follow()
    {
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
            destination -= player.GetComponent<Transform>().forward;
        }

        agent.destination = destination;
        //transform.GetChild(1).transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void Return()
    {
        returning = true;
        following = false;
        agent.enabled = true;
        agent.destination = startPosition;
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }


}
