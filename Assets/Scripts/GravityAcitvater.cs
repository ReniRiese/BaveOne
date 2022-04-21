using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GravityAcitvater : MonoBehaviour
{
    public GravityGiver gravityObject;

    static float maxCoolDown = 5f;
    static float _coolDown;
    static bool _coolDownStarted;

    public void Update()
    {
        if (_coolDownStarted)
        {
            _coolDown += Time.deltaTime;
        }
        
        if (_coolDown > maxCoolDown)
        {
            _coolDown = 0;
            _coolDownStarted = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _coolDown == 0f)
        {
            GravityAcceptor given = other.GetComponent<GravityAcceptor>();
            if (given.gravityGiver != gravityObject)
            {
                _coolDownStarted = true;
                given.gravityGiver = gravityObject;
                given.SetLastMovementToZero();
            }
        }
    }
}