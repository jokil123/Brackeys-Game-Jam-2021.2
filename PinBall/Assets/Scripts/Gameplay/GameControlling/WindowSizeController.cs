using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSizeController : MonoBehaviour
{
    Vector2Int lastWindowSize;
    Vector2Int lastWindowPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(lastWindowSize.x, lastWindowSize.y, false);
                Debug.Log("Switched to window mode");
            } 
            else
            {
                lastWindowSize = new Vector2Int(Screen.width, Screen.height);

                Resolution res = Screen.currentResolution;
                Screen.SetResolution(res.width, res.height, true);
                Debug.Log("Switched to fullscreen");
            }
            
        }
    }
}
