using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
 
    GameObject targetObj;
   
    GameObject GObjA;
    GameObject GObjB;
    GameObject GObjC;
    GameObject GObjD;

    int sense;
    int targetNum;

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
        GObjA = GameObject.Find("WP A");
        GObjB = GameObject.Find("WP B");
        GObjC = GameObject.Find("WP C");
        GObjD = GameObject.Find("WP D");

        targetNum = Random.Range(0, 4);
        sense = Random.Range(0, 2);

        changeTarget();

        agent.destination = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
