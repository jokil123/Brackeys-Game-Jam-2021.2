using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Pedal leftPedal;
    public Pedal rightPedal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Quit Game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        // Player Input For Pedals
        leftPedal.Animate(Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow)));
        rightPedal.Animate(Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)));
    }
}
