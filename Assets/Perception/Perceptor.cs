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
        public enum senses { VISION, SOUND };
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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Zombie";
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

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
                        gameObject.SendMessage("followFarmer", hit.collider.gameObject);
                        Debug.Log("Wander in frustum");
                    }
                // Your code!!
            }
        }
    }
    void followFarmer(GameObject farmer)
    {
        agent.destination = farmer.transform.position;
    }

}