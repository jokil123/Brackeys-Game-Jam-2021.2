using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public Transform ballSpawner;
    public GameObject ballPrefab;
    public bool gameIsRunning = false;
    public Text ballCountTxt;

    private ScoreSystem scoreSystem;
    private int maxBalls = 0;
    private int ballsToSpawn = 0;
    private int wave = 1;
    private int ballCount;

    public int BallCount
    {
        get { return ballCount; }
        set { 
            ballCount = value;
            ballCountTxt.text = $"Ball Count: {value}";
        }
    }

    private void Start()
    {
        scoreSystem = GetComponent<ScoreSystem>();
        BallCount = 0;
    }

    private IEnumerator SpawnBalls()
    {
        while (gameIsRunning)
        {
            if (BallCount < maxBalls)
            {
                AddBall();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddBall()
    {
        GameObject.Instantiate(ballPrefab, ballSpawner.position, ballSpawner.rotation);
        BallCount += 1;
    }

    public void AddBallsToSpawn()
    {
        maxBalls = Mathf.FloorToInt((50 - (50 - 1) * Mathf.Exp(-0.02f * wave)));
        ballsToSpawn = maxBalls - BallCount;
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
        BallCount = 0;

        maxBalls = 1;
        wave = 1;
        ballsToSpawn = 1;
        gameIsRunning = true;
        StartCoroutine(SpawnBalls());
    }
}
