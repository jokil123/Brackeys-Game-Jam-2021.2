using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    public Transform targetTransform;
    public Transform restTransform;

    public float animationSpeed;

    private float currentAnimationValue;
    private float targetAnimationValue;

    private GameObject AnimationPivot;
    private Rigidbody AnimationRigidBody;

    public void Animate(float target)
    {
        targetAnimationValue = target;
    }

    void Awake()
    {
        AnimationPivot = gameObject.transform.Find("AnimationPivot").gameObject;
        AnimationRigidBody = AnimationPivot.GetComponent<Rigidbody>();
    }
     

    void Update()
    {
        InterpolateToTarget();
        UpdateAnimationState();
    }

    void InterpolateToTarget()
    {
        float animationDelta = targetAnimationValue - currentAnimationValue;

        Debug.Log(animationDelta);

        if (Mathf.Abs(animationDelta) < animationSpeed)
        {
            currentAnimationValue = targetAnimationValue;
        }
        else
        {
            int animationDirection = (int)Mathf.Sign(animationDelta);

            currentAnimationValue += animationDirection * animationSpeed;
        }

        currentAnimationValue = Mathf.Clamp(currentAnimationValue, 0, 1);
    }

    void UpdateAnimationState()
    {
        Vector3 interpolatedPosition = Vector3.Lerp(restTransform.position, targetTransform.position, currentAnimationValue);

        Quaternion interpolatedRotation = Quaternion.Slerp(restTransform.rotation, targetTransform.rotation, currentAnimationValue);

        Vector3 interpolatedScale = Vector3.Lerp(restTransform.localScale, targetTransform.localScale, currentAnimationValue);

        AnimationRigidBody.MovePosition(interpolatedPosition);
        AnimationRigidBody.MoveRotation(interpolatedRotation);
        AnimationPivot.transform.localScale = interpolatedScale;
    }
}
