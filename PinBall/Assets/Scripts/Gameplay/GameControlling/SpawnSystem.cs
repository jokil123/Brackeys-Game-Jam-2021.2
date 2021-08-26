using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform ballSpawner;
    public GameObject ballPrefab;
    public bool gameIsRunning = false;

    private int maxBalls = 0;
    public int ballCount = 0;
    private int ballsToSpawn = 0;
    private int wave = 1;

    private IEnumerator SpawnBalls()
    {
        while (gameIsRunning)
        {
            if (ballCount < maxBalls)
            {
                GameObject.Instantiate(ballPrefab, ballSpawner.position, ballSpawner.rotation);
                ballCount += 1;
            }
            Debug.Log("tick");
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddBallsToSpawn()
    {
        maxBalls = Mathf.FloorToInt((50 - (50 - 1) * Mathf.Exp(-0.02f * wave)));
        ballsToSpawn = maxBalls - ballCount;
        Debug.Log("New ballsToSpawn: " + ballsToSpawn);
        wave++;
    }

    public void StartGame()
    {
        maxBalls = 1;
        ballsToSpawn = 1;
        gameIsRunning = true;
        StartCoroutine(SpawnBalls());
    }
}
