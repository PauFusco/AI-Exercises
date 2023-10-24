using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Policeman_Guide : MonoBehaviour
{
    public NavMeshAgent ghostAgent;
    public NavMeshAgent patrolAgent;

    public GameObject[] waypoints;
    int patrolWP;
    int direction;

    void Seek(Vector3 WPpos)
    {
        ghostAgent.destination = WPpos;
    }
    void SeekSwitch()
    {
        if (patrolAgent.remainingDistance > 10) ghostAgent.isStopped = true;
        else ghostAgent.isStopped = false;
    }
    void Patrol()
    {
        int dirNum = -1;
        switch (direction)
        {
            case 0:
                dirNum = 1;
                break;
            case 1:
                dirNum = -1;
                break;
        }
        patrolWP = (patrolWP + dirNum);

        if (patrolWP < 0) patrolWP = waypoints.Length - 1;
        if (patrolWP > waypoints.Length) patrolWP %= waypoints.Length;

        Seek(waypoints[patrolWP].transform.position);
    }
    private void Start()
    {
        patrolWP = Random.Range(0, 4);
        direction = Random.Range(0, 2);
    }

    private void Update()
    {
        if (!ghostAgent.pathPending && ghostAgent.remainingDistance < 0.5f) Patrol();

        SeekSwitch();
    }
}