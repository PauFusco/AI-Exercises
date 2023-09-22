using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    
    // parameters: float radius, offset;
    float radius = 2;
    float offset = 1;
    
    public UnityEngine.AI.NavMeshAgent agent;
    
    UnityEngine.AI.NavMeshHit hit;
    Vector3 localTarget;
    Vector3 worldTarget;
    
    int i;
    
    // Update is called once per frame
    void Update()
    {
        localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        
        int i = 0;
        
        while (!UnityEngine.AI.NavMesh.SamplePosition(worldTarget, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas) && i < 10)
        {
            localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            i++;
        }
    
        agent.destination = worldTarget;

        // Debug.DrawRay(worldTarget, Vector3.up, Color.blue, 1.0f);
    }
}