using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public Vector3 gravityDirection = new Vector3(0, -1, 0);

    public float gravityStrength = 9.81f;

    public bool showGravityArrow;

    void Awake()
    {
        Physics.gravity = gravityDirection.normalized * gravityStrength;
        // Debug.Log(Physics.gravity.y);
    }

    void OnDrawGizmos()
    { 
        if (showGravityArrow)
        {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + gravityDirection.normalized * gravityStrength;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
        }
    }
}
