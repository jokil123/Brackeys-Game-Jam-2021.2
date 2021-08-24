using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BouncePad : TriggerPad
{
    public Vector3 bounceDirection;
    public float bounceStrengthMultiplier;
    public BounceType bounceType;

    public override void TriggerAction(List<GameObject> bounceObjects)
    {
        if (triggerEnabled)
        {
            lastTriggered = Time.time;
            foreach (GameObject bounceObject in bounceObjects)
            {
                bounceObject.GetComponent<Rigidbody>().AddForce(GetLaunchVector());
            }
        }
    }

    Vector3 GetLaunchVector()
    {
        return gameObject.transform.rotation * bounceDirection * bounceStrengthMultiplier;

    }



    private void OnDrawGizmos()
    {
        if (bounceType == BounceType.directional)
        {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + GetLaunchVector() * Config.GizmoVectorLengthMultiplier;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
        }
    }
}

public enum BounceType
{
    directional,
    radial,
    reflect,
    random
}