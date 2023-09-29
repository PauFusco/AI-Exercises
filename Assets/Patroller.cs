using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
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