using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{ 
    public float animationSpeed;

    private float currentAnimationValue;
    private float targetAnimationValue;

    private Animator animationComponent;

    public void Animate(float target)
    {
        targetAnimationValue = target;
    }

    void Awake()
    {
        animationComponent = GetComponentInChildren<Animator>();
    }

    void Update ()
    {
        InterpolateToTarget();
    }

    void InterpolateToTarget()
    {
        float animationDelta = targetAnimationValue - currentAnimationValue;

        if (animationDelta < animationSpeed)
        {
            currentAnimationValue = targetAnimationValue;
        }
        else
        {
            int animationDirection = (int)Mathf.Sign(animationDelta);
            currentAnimationValue = animationDirection * animationSpeed;
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        float animationDuration= animationComponent.GetCurrentAnimatorClipInfo(0)[0].clip.length;

        animationComponent.SetFloat("AnimationTime", animationDuration * currentAnimationValue);
    }
}
