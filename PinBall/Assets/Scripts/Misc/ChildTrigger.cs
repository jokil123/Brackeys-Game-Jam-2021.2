using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ChildTriggerEnter
{
    void OnTriggerEnterChild(Collider childCollider, Collider other);
}

interface ChildTriggerExit 
{
    void OnTriggerExitChild(Collider childCollider, Collider other);
}

public class ChildTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ChildTriggerEnter parentInterfaceComponent = GetComponentInParent<ChildTriggerEnter>();
        if (parentInterfaceComponent != null)
        {
            parentInterfaceComponent.OnTriggerEnterChild(gameObject.GetComponent<Collider>(), other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ChildTriggerExit parentInterfaceComponent = GetComponentInParent<ChildTriggerExit>();
        if (parentInterfaceComponent != null)
        {
            parentInterfaceComponent.OnTriggerExitChild(gameObject.GetComponent<Collider>(), other);
        }
    }
}
