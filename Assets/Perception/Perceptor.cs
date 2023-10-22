using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptor : MonoBehaviour
{
    public PerceptorManager perceptorManager;

    public Camera frustum;
    public LayerMask mask;
    public class PerceptionEvent
    {
        public enum senses { VISION };
        public enum types { NEW, LOST };
        public enum threatLvls { FRIEND, SUS, THREAT }
        public GameObject gObj;
        public senses sense;
        public types type;
        public threatLvls threatLvl;
    }

    public UnityEngine.AI.NavMeshAgent agent;

    Vector3 tempTarget;
    Vector3 worldTarget;
    public bool following = false;

    float timeMin = 0.3f;
    float timeMax = 0.8f;
    float waitTime = 0.0f;

    public float radius = 1;
    public float offset = 1;

    private UnityEngine.AI.NavMeshHit hat;

    void Start()
    {
        gameObject.tag = "Zombie";
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        following = false;

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                RaycastHit hit;
                Ray ray = new Ray();
                ray.origin = transform.position;
                ray.direction = (col.transform.position - transform.position).normalized;
                ray.origin = ray.GetPoint(frustum.nearClipPlane);

                if (Physics.Raycast(ray, out hit, frustum.farClipPlane, mask))
                    if (hit.collider.gameObject.CompareTag("Wander"))
                    {
                        perceptorManager.BroadCast(hit.collider.gameObject);
                        following = true;
                    }
            }
        }
        if (!following)
        {
            waitTime -= Time.deltaTime;

            if (waitTime <= 0.0f)
            {
                tempTarget = UnityEngine.Random.insideUnitCircle * radius;
                tempTarget += new Vector3(0, 0, offset);
                worldTarget = transform.TransformPoint(tempTarget);
                worldTarget.y = 0f;
                if (UnityEngine.AI.NavMesh.SamplePosition(worldTarget, out hat, 1.0f, UnityEngine.AI.NavMesh.AllAreas)) agent.destination = hat.position;

                waitTime = Random.Range(timeMin, timeMax);
            }
        }
    }
    void followFarmer(GameObject farmer)
    {
        agent.destination = farmer.transform.position;
    }
}