using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Collectible : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.transform.position =
                new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);
        }
    }
}
