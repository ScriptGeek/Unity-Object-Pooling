using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script must be attached to the Cube prefab. This script handles the resetting of variables when respawning. The functionality of this script can be placed into other scripts attached; however, it must be pointed out that the resetting code be contained within the OnEnable method on a script attached to the GameObject instance.
/// </summary>
public class ResetOnRespawn : MonoBehaviour
{
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Reset the object properties here.
    /// </summary>
    private void OnEnable()
    {
        rb.velocity = Vector3.zero; 
    }


}
