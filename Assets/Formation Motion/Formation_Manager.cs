using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Formation_Manager : MonoBehaviour
{
    public Leader_Behaviour leader;
    public GameObject formant;
    public int numFormant = 8;
    public GameObject[] allFormants;

    [Header("Formant Settings")]
    [Range(1.0f, 5.0f)]
    public float formantDistance = 1.5f;

    public float FormantRowNumber = 3;

    // Use this for initialization
    private void Start()
    {
        Vector3 leaderPos = leader.agent.transform.position;
        Vector3 pos = new Vector3(0, leaderPos.y, 0);
        allFormants = new GameObject[numFormant];

        int n = 0;

        for (int i = -1; i <= 1; i++)
        {
            pos.x = leaderPos.x + i * formantDistance;

            for (int j = -2; j <= 0; j++)
            {
                pos.z = leaderPos.z - j * formantDistance;
                if (leaderPos.x != pos.x || leaderPos.z != pos.z)
                {
                    allFormants[n] = (GameObject)Instantiate(formant, pos, Quaternion.identity);
                    allFormants[n].GetComponent<FormantBehaviour>().leader = leader;
                    n++;
                }
            }
        }
    }
}