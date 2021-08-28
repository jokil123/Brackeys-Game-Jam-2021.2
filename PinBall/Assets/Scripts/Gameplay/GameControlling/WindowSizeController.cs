using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSizeController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
            Debug.Log("Switched to/from fullscreen");
        }
        
    }
}
