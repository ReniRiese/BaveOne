using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public GravityGiver firstGravity;
    public GravityGiver secondGravity;

    public void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("Player"))
        {
            GravityAcceptor given = other.GetComponent<GravityAcceptor>();
            if (given.gravityGiver == firstGravity)
            {
                given.gravityGiver = secondGravity;
            }
            else
            {
                given.gravityGiver = firstGravity;
            }
        }
    }
}