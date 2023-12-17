using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager : MonoBehaviour
{
    public GameObject officer;
    public int numOfficers = 6;
    public GameObject[] allPolice;

    [Header("Formant Settings")]
    [Range(1.0f, 5.0f)]
    public float formantDistance = 1f;

    public float FormantRowNumber = 3;

    // Use this for initialization
    private void Start()
    {
        Vector3 leaderPos = transform.position;
        Vector3 pos = new Vector3(0, leaderPos.y, 0);
        allPolice = new GameObject[numOfficers];

        int n = 0;

        for (int i = -1; i <= 1; i++)
        {
            pos.x = leaderPos.x + i * formantDistance;

            for (int j = -2; j <= 0; j++)
            {
                pos.z = leaderPos.z - j * formantDistance;
                if (leaderPos.x != pos.x || leaderPos.z != pos.z)
                {
                    allPolice[n] = (GameObject)Instantiate(officer, pos, Quaternion.identity);
                    n++;
                }
            }
        }
    }
}