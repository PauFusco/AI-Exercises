using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    
    GameObject guide;
    
    void Start()
    {
        guide = GameObject.Find("Patrol Guide");
    }
    void Update()
    {
        agent.destination = guide.transform.position;
    }
}
