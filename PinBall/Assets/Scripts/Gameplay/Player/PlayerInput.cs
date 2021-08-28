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
        // Quit Game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        // Player Input For Pedals
        leftPedal.Animate(Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow)));
        rightPedal.Animate(Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)));

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

        // Sound For Pedals

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPedal.pedalSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPedal.pedalSound.Play();
        }
    }
}
