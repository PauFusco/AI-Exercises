using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    
    // parameters: float radius, offset;
    float radius = 1;
    float offset = 1;
    
    public UnityEngine.AI.NavMeshAgent agent;
    
    UnityEngine.AI.NavMeshHit hit;
    Vector3 tempTarget;
    Vector3 worldTarget;
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            tempTarget = UnityEngine.Random.insideUnitCircle * radius;
            tempTarget += new Vector3(0, 0, offset);
            worldTarget = transform.TransformPoint(tempTarget);
            worldTarget.y = 0f;
            if (UnityEngine.AI.NavMesh.SamplePosition(worldTarget, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas)) break;
        }

        agent.destination = worldTarget;
    }
}