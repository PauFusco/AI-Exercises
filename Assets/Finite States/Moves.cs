using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    // Behaviour function

    public void Wander()
    {
        Debug.Log("Wander active");
    }

    public void Seek(Vector3 position)
    {
        Debug.Log("Seek active");
    }

    public void Hide()
    {
        Debug.Log("Hide active");
    }
}