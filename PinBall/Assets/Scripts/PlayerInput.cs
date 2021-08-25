using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Left Handle up
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            // Left Handle down
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Right Handle up
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            // Right Hanlde down
        }
    }
}
