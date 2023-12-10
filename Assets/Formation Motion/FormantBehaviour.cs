using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FormantBehaviour : MonoBehaviour
{
    public Leader_Behaviour leader;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        agent.destination = leader.agent.destination + (agent.transform.position - leader.transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}