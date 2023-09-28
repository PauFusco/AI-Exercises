using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGhost : MonoBehaviour
{
    Patroller PatrolClass;

    public UnityEngine.AI.NavMeshAgent agent;

    UnityEngine.AI.NavMeshAgent patrolagent;
    
    GameObject targetObj;
    
    GameObject patroller;

    GameObject GObjA;
    GameObject GObjB;
    GameObject GObjC;
    GameObject GObjD;

    int sense;
    int targetNum;
    float d;
    void changeTarget()
    {
        switch (targetNum)
        {
            case 0:
                targetObj = GObjA;
                break;
            case 1:
                targetObj = GObjB;
                break;
            case 2:
                targetObj = GObjC;
                break;
            case 3:
                targetObj = GObjD;
                break;
        }
    }
    void Start()
    {
        patrolagent = PatrolClass.agent;

        GObjA = GameObject.Find("WP A");
        GObjB = GameObject.Find("WP B");
        GObjC = GameObject.Find("WP C");
        GObjD = GameObject.Find("WP D");

        patroller = GameObject.Find("Patroller");

        targetNum = Random.Range(0, 4);
        sense = Random.Range(0, 2);

        changeTarget();

        agent.destination = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        patrolagent.remainingDistance;

        if (d > 1.0f)
        {
            agent.isStopped = true;
        }
        if (d < 1.0f)
        {
            agent.isStopped = false;
        }

        if (agent.remainingDistance < 0.3f)
        {
            switch (sense)
            {
                // Clock-wise
                case 0:
                    targetNum--;
                    if (targetNum < 0)    targetNum = 3;
                    
                    changeTarget();
                   
                    break;

                //Counterclock-wise
                case 1:
                    targetNum++;
                    if (targetNum > 3)    targetNum = 0;
                    
                    changeTarget();
                    
                    break;
            }
            
            agent.destination = targetObj.transform.position;
        }
        
    }
}
