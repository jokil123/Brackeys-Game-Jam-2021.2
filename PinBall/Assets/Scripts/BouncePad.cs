using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BouncePad : MonoBehaviour, ChildTriggerEnter, ChildTriggerExit
{
    public bool bounceEnabled;
    public float bounceDelay;
    public float bounceCooldown;
    public BounceType bounceType;

    public Vector3 bounceDirection;
    public float bounceStrengthMultiplier;

    public bool bounceSeperately;


    private float LastBounce;

    private HashSet<GameObject> collidedList = new HashSet<GameObject>();
    private Dictionary<GameObject, float> collidedListTime = new Dictionary<GameObject, float>();


    void FixedUpdate()
    {
        HashSet<GameObject> toBounce = new HashSet<GameObject>();

        if (Time.time - LastBounce >= bounceCooldown)
        {
            foreach (GameObject collidedObject in collidedList)
            {
                if (Time.time - collidedListTime[collidedObject] >= bounceDelay)
                {
                    toBounce.Add(collidedObject);
                }
            }

            if (bounceSeperately)
            {
                Bounce(toBounce.ToList());
            }
            else
            {
                if (toBounce.Count > 0)
                {
                    Bounce(collidedList.ToList());
                }
            }
        }
    }

    void Bounce(List<GameObject> bounceObjects)
    {
        if (bounceEnabled)
        {
            LastBounce = Time.time;
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



    public void OnTriggerEnterChild(Collider childCollider, Collider other)
    {
        collidedList.Add(other.gameObject);
        collidedListTime.Add(other.gameObject, Time.time);
        Debug.LogWarning("Child Enter");
    }

    public void OnTriggerExitChild(Collider childCollider, Collider other)
    {
        collidedList.Remove(other.gameObject);
        collidedListTime.Remove(other.gameObject);
        Debug.LogWarning("Child Exit");
    }

    private void OnDrawGizmos()
    {
        if (bounceType == BounceType.directional) {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + GetLaunchVector() * Config.GizmoVectorLengthMultiplier;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
        }
    }
}

public enum BounceType
{
    radial,
    directional,
    reflect,
    random
}