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
                bounceObject.GetComponent<Rigidbody>().AddForce(GetLaunchVector(bounceObject));
            }
        }
    }

    Vector3 GetLaunchVector(GameObject bounceObject)
    {
        Vector3 bounceDireciton = Vector3.zero;

        switch (bounceType)
        {
            case BounceType.directional:
                bounceDireciton = gameObject.transform.rotation * bounceDirection;
                break;
            case BounceType.radial:
                bounceDireciton = bounceObject.transform.position - gameObject.transform.position;

                break;
            case BounceType.reflect:

                break;
            case BounceType.random:
                bounceDireciton = Random.insideUnitSphere;
                break;
        }



        return bounceDireciton.normalized * bounceStrengthMultiplier;
    }



    private void OnDrawGizmos()
    {
        if (bounceType == BounceType.directional)
        {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + GetLaunchVector(gameObject) * Config.GizmoVectorLengthMultiplier; // Oof, very dirty code right here
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