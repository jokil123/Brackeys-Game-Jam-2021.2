using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform ballSpawner;
    public GameObject ballPrefab;
    public bool gameIsRunning = false;

    private ScoreSystem scoreSystem;

    private int maxBalls = 0;
    public int ballCount = 0;
    private int ballsToSpawn = 0;
    private int wave = 1;

    private void Start()
    {
        scoreSystem = GetComponent<ScoreSystem>();
    }

    private IEnumerator SpawnBalls()
    {
        while (gameIsRunning)
        {
            if (ballCount < maxBalls)
            {
                GameObject.Instantiate(ballPrefab, ballSpawner.position, ballSpawner.rotation);
                ballCount += 1;
                scoreSystem.Score += 1;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddBallsToSpawn()
    {
        maxBalls = Mathf.FloorToInt((50 - (50 - 1) * Mathf.Exp(-0.05f * wave)));
        ballsToSpawn = maxBalls - ballCount;
        wave++;
    }

    public void StartGame()
    {
        // Reset Score
        scoreSystem.Score = 0;

        // Stop previous Coroutine
        StopCoroutine(SpawnBalls());

        // Clear all remaining Balls
        GameObject[] b = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject item in b)
        {
            GameObject.Destroy(item);
        }
        ballCount = 0;

        maxBalls = 1;
        ballsToSpawn = 1;
        gameIsRunning = true;
        StartCoroutine(SpawnBalls());
    }
}
