using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robber : MonoBehaviour
{
    public NavMeshAgent Policeman;

    public GameObject treasure;
    float dist2Steal = 1f;
    float dist2Cop = 5f;
    Moves moves;
    NavMeshAgent agent;

    bool stolen = false;

    private WaitForSeconds wait = new WaitForSeconds(0.05f); // == 1/20
    delegate IEnumerator State();
    private States state;

    enum States
    {
        Wander,
        Seek,
        Hide
    }

    void Start()
    {
        moves = gameObject.GetComponent<Moves>();
        agent = gameObject.GetComponent<NavMeshAgent>();

        agent.speed = 1.5f;

        state = States.Wander;

        StartCoroutine(switchState());
    }
    IEnumerator switchState()
    {
        while (true)
        {
            switch (state)
            {
                case States.Wander:
                    Debug.Log("Wander state");
                    state = IsGuarded() ? States.Wander : States.Seek;

                    yield return Wander();
                    break;

                case States.Seek:
                    Debug.Log("Approaching state");
                    state = IsGuarded() ? States.Wander : States.Seek;
                    if (CanSteal() && !stolen)
                    {
                        Debug.Log("Can steal");
                        treasure.SetActive(false);
                        state = States.Hide;
                    }
                    yield return Approaching();
                    break;

                case States.Hide:
                    Debug.Log("Hiding state");
                    agent.speed = 2f;
                    yield return Hiding();
                    break;
            }
            yield return switchState();
        }
    }

    IEnumerator Wander()
    {
        moves.Wander();
        yield return null;
    }
    IEnumerator Approaching()
    {
        moves.Seek(treasure.transform.position);
        yield return null;
    }
    IEnumerator Hiding()
    {
        moves.Hide(Policeman);
        yield return null;
    }

    bool IsGuarded()
    {
        return (Vector3.Distance(Policeman.transform.position, treasure.transform.position) <= dist2Cop);
    }
    bool CanSteal()
    {
        return (Vector3.Distance(agent.transform.position, treasure.transform.position) <= dist2Steal);
    }
}
