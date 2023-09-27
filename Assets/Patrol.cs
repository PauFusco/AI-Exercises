using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
 
    GameObject targetObj;
   
    int sense;

    void Start()
    {
        var GObjA = GameObject.Find("WP A");
        var GObjB = GameObject.Find("WP B");
        var GObjC = GameObject.Find("WP C");
        var GObjD = GameObject.Find("WP D");

        var targetNum = Random.Range(0, 3);
        sense = Random.Range(0, 1);

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

        agent.destination = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // use objects as targets and alternate between them
        // put objects in a list and assign numbers to make it as a loop of (int i = 0; i < n; i++;) where n is max target attributed number
        // if (current position == target && target != n) -> target = next target

        if (agent.transform.position == targetObj.transform.position)
        {
            switch (sense)
            {
                // Clock-wise
                case 0:


                    break;

                //Counterclock-wise
                case 1:


                    break;
            }
        }
        
    }
}
