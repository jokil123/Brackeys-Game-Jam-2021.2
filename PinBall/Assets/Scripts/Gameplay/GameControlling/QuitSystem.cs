using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSystem : MonoBehaviour
{
    void Update()
    {
        // Quit Game
        if (Input.GetKey(KeyCode.Q) || (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F4)))
        {
            Application.Quit();
        }
    }
}
