using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Pedal leftPedal;
    public Pedal rightPedal;

    private SpawnSystem spawnSystem;
    public GameObject startScreen;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        spawnSystem = GetComponent<SpawnSystem>();
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Player Input For Pedals

        bool leftKeyBool = false;
        bool leftKeyDownBool = false;

        List<KeyCode> leftKeys = new List<KeyCode>();
        leftKeys.Add(KeyCode.A);
        leftKeys.Add(KeyCode.LeftArrow);
        leftKeys.Add(KeyCode.Y);
        leftKeys.Add(KeyCode.X);


        bool rightKeyBool = false;
        bool rightKeyDownBool = false;

        List<KeyCode> rightKeys = new List<KeyCode>();
        rightKeys.Add(KeyCode.D);
        rightKeys.Add(KeyCode.RightArrow);
        rightKeys.Add(KeyCode.Period);
        rightKeys.Add(KeyCode.Comma);


        foreach (KeyCode key in leftKeys)
        {
            leftKeyBool = leftKeyBool || Input.GetKey(key);
            leftKeyDownBool = leftKeyDownBool || Input.GetKeyDown(key);
        }

        foreach (KeyCode key in rightKeys)
        {
            rightKeyBool = rightKeyBool || Input.GetKey(key);
            rightKeyDownBool = rightKeyDownBool || Input.GetKeyDown(key);
        }


        leftPedal.Animate(Convert.ToInt32(leftKeyBool));
        rightPedal.Animate(Convert.ToInt32(rightKeyBool));


        // Sound For Pedals

        if (leftKeyDownBool)
        {
            leftPedal.pedalSound.Play();
        }
        if (rightKeyDownBool)
        {
            rightPedal.pedalSound.Play();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!spawnSystem.gameIsRunning)
            {
                spawnSystem.StartGame();
                startScreen.SetActive(false);
                gameOverUI.SetActive(false);
                Debug.Log("Started Game!");
            }
        }
    }
}
