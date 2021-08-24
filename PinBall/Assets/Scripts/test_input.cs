using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class test_input : MonoBehaviour
{
    private float animationValue;

    void Update()
    {
        animationValue = Convert.ToInt32(Input.GetKey(KeyCode.Space));

        GetComponent<Pedal>().Animate(animationValue);
    }
}
