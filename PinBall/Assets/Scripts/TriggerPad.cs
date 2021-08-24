using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TriggerPad : MonoBehaviour, ChildTriggerEnter, ChildTriggerExit
{
    public bool triggerEnabled;
    public float triggerDelay;
    public float triggerCooldown;
    

    public bool triggerSeperately;

    [HideInInspector]
    public float lastTriggered;

    private HashSet<GameObject> collidedList = new HashSet<GameObject>();
    private Dictionary<GameObject, float> collidedListTime = new Dictionary<GameObject, float>();


    void FixedUpdate()
    {
        FindTriggerActionObjects();
    }


    public void FindTriggerActionObjects()
    {
        HashSet<GameObject> triggerActionObjects = new HashSet<GameObject>();

        if (Time.time - lastTriggered >= triggerCooldown)
        {
            foreach (GameObject collidedObject in collidedList)
            {
                if (Time.time - collidedListTime[collidedObject] >= triggerDelay)
                {
                    triggerActionObjects.Add(collidedObject);
                }
            }

            if (triggerSeperately)
            {
                TriggerAction(triggerActionObjects.ToList());
            }
            else
            {
                if (triggerActionObjects.Count > 0)
                {
                    TriggerAction(collidedList.ToList());
                }
            }
        }
    }

    public virtual void TriggerAction(List<GameObject> triggerActionObjects)
    {

    }

    public void OnTriggerEnterChild(Collider childCollider, Collider other)
    {
        collidedList.Add(other.gameObject);
        collidedListTime.Add(other.gameObject, Time.time);
        // Debug.LogWarning("Child Enter");
    }

    public void OnTriggerExitChild(Collider childCollider, Collider other)
    {
        collidedList.Remove(other.gameObject);
        collidedListTime.Remove(other.gameObject);
        // Debug.LogWarning("Child Exit");
    }
}