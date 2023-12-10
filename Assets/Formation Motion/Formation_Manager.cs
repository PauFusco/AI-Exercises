using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation_Manager : MonoBehaviour
{
    public Leader_Behaviour leader;
    public GameObject formant;
    public int numFormant = 8;
    public GameObject[] allFormants;

    [Header("Formant Settings")]
    [Range(1.0f, 5.0f)]
    private float formantDistance = 2.0f;

    public float FormantRowNumber = 3;

    // Use this for initialization
    private void Start()
    {
        Vector3 leaderPos = leader.agent.transform.position;
        float y = leaderPos.y;
        Vector3 pos = new Vector3(0, y, leaderPos.z);
        allFormants = new GameObject[numFormant];

        float z = leaderPos.z - (formantDistance * numFormant % FormantRowNumber);

        for (int i = 0; i < numFormant; i++)
        {
            if (z > formantDistance * (numFormant % FormantRowNumber)) pos.x += formantDistance;

            pos.z = z;

            allFormants[i] = (GameObject)Instantiate(formant, pos, Quaternion.identity);
            allFormants[i].GetComponent<FormantBehaviour>().leader = leader;

            z += formantDistance;
        }
    }
}