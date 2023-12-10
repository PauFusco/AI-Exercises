using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader_Behaviour : MonoBehaviour
{
    public Formation_Manager manager;
    public UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        Vector3 endpoint = new Vector3(0, 0, -14);
        agent.destination = endpoint;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}