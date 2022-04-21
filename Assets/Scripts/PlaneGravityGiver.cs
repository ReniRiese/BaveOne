using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGravityGiver : GravityGiver
{
    private Plane thisPlane;

    // Start is called before the first frame update
    void Start()
    {
        thisPlane = new Plane(transform.up, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        thisPlane = new Plane(transform.up, transform.position);
    }

    public override Vector3 GetGravityVector(GameObject gameObject)
    {
        float normalVector = thisPlane.GetDistanceToPoint(gameObject.transform.position);
        
        return normalVector > 0 ? (transform.up * -1) : transform.up;
    }
}