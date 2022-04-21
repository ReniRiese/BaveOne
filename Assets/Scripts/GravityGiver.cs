using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GravityGiver : MonoBehaviour
{
    public abstract Vector3 GetGravityVector(GameObject gameObject);
}
