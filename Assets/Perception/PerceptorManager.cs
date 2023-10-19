using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptorManager : MonoBehaviour
{
    public GameObject ZombiePreFab;
    public int numZoms = 20;
    public GameObject[] allZoms;
    public Vector3 spawnLimits = new Vector3(1, 1, 1);

    [Range(1.0f, 10.0f)]
    public float neighbourDistance;

    // Use this for initialization
    void Start()
    {
        allZoms = new GameObject[numZoms];
        for (int i = 0; i < numZoms; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-spawnLimits.x, spawnLimits.x),
                                                                Random.Range(-spawnLimits.y, spawnLimits.y),
                                                                Random.Range(-spawnLimits.z, spawnLimits.z));
            allZoms[i] = (GameObject)Instantiate(ZombiePreFab, pos, Quaternion.identity);
            allZoms[i].GetComponent<Perceptor>().perceptorManager = this;

            allZoms[i].transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BroadCast(GameObject target)
    {
        gameObject.BroadcastMessage("followFarmer", target);
    }
}
