using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    PatrolGhost ghostScript;

    public NavMeshAgent patrolAgent;
    public NavMeshAgent ghostAgent;
    
    void Start()
    {
    }
    void Update()
    {
        patrolAgent.destination = ghostAgent.transform.position;
    }
}
