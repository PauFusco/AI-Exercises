using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    float timeMin = 0.3f;
    float timeMax = 0.8f;
    float waitTime = 0.0f;
    // parameters: float radius, offset;
    public float radius = 1;
    public float offset = 1;

    public UnityEngine.AI.NavMeshAgent agent;

    UnityEngine.AI.NavMeshHit hit;
    Vector3 tempTarget;
    Vector3 worldTarget;

    void Start()
    {
        gameObject.tag = "Wander";
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0.0f)
        {
            tempTarget = UnityEngine.Random.insideUnitCircle * radius;
            tempTarget += new Vector3(0, 0, offset);
            worldTarget = transform.TransformPoint(tempTarget);
            worldTarget.y = 0f;
            if(UnityEngine.AI.NavMesh.SamplePosition(worldTarget, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))  agent.destination = hit.position;

            waitTime = Random.Range(timeMin, timeMax);
        }
    }
}