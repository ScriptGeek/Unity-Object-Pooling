using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlane : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        UsageTest.Instance.Remove(collision.gameObject);
    }

}
