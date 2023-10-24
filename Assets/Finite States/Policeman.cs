using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    Policeman_Guide ghostScript;

    public UnityEngine.AI.NavMeshAgent patrolAgent;
    public UnityEngine.AI.NavMeshAgent ghostAgent;

    void Start()
    {
    }
    void Update()
    {
        patrolAgent.destination = ghostAgent.transform.position;
    }
}
