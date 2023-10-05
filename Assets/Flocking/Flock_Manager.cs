using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock_Manager : MonoBehaviour
{
    public Flocking flock;
    public GameObject fishPrefab;

    public int numFish = 10;
    public GameObject[] allFish;

    public float neighbourDistance = 0.5f;

    public float minSpeed = 1;
    public float maxSpeed = 5;

    public Vector3 direction;

    Vector3 SetRandomVector()
    {
        Vector3 randVec;
        int x, y, z;

        x = Random.Range(-2, 3);
        y = Random.Range(-2, 3);
        z = Random.Range(-2, 3);
        randVec.x = x;
        randVec.y = y;
        randVec.z = z;

        return randVec;
    }

    void Start()
    {
        direction = SetRandomVector();
    }

    void Update()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 pos = this.transform.position + SetRandomVector(); // random position
            Vector3 randomize = SetRandomVector(); // random vector direction

            allFish[i] = (GameObject)Instantiate(fishPrefab, pos,
                                Quaternion.LookRotation(randomize));

            allFish[i].GetComponent<Flocking>().fManager = this;
        }
    }
}
