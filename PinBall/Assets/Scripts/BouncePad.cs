using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public bool bounceEnabled;
    public float bounceDelay;
    public BounceType bounceType;

    public Vector3 bounceDirection;
    public float bounceStrengthMultiplier;

    private Collider bounceTrigger;


    // Start is called before the first frame update
    void Start()
    {
        bounceTrigger = gameObject.transform.Find("BounceTrigger").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (bounceType == BounceType.directional) {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + bounceDirection * bounceStrengthMultiplier;
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