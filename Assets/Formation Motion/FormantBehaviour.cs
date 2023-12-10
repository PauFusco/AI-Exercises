using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FormantBehaviour : MonoBehaviour
{
    public Leader_Behaviour leader;
    public NavMeshAgent agent;

    private Vector3 trueDistance;

    // Start is called before the first frame update
    private void Start()
    {
        trueDistance = agent.transform.position - leader.transform.position;
        agent.destination = leader.agent.destination + trueDistance;
        transform.rotation = leader.transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.speed = (agent.destination - transform.position).magnitude + 2;
        agent.destination = leader.transform.position + trueDistance;
        transform.rotation = leader.transform.rotation;
    }
}