using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGravityGiver : GravityGiver
{
    // Update is called once per frame
    public override Vector3 GetGravityVector(GameObject gameObject)
    {
        return (transform.position - gameObject.transform.position).normalized;
    }
}