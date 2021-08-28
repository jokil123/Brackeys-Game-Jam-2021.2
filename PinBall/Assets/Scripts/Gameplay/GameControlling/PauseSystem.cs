using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
