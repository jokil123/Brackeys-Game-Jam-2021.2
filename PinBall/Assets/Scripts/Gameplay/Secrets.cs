using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secrets : MonoBehaviour
{
    private SpawnSystem spawnSystem;

    public bool invincibilityOn = false;


    public bool neverEnabled = true;
    public bool longTrails = false;

    public float normalTrailLength;

    public bool zeroG = false;

    public Vector3 gravity;

    private void Awake()
    {
        spawnSystem = gameObject.GetComponent<SpawnSystem>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            spawnSystem.AddBall();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            invincibilityOn = !invincibilityOn;
        }


        if (Input.GetKeyDown(KeyCode.F3))
        {
            neverEnabled = false;
            longTrails = !longTrails;
        }

        if (!neverEnabled)
        {
            if (longTrails)
            {
                GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

                foreach (GameObject ball in balls)
                {
                    ball.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().time = 10;
                }

                normalTrailLength = spawnSystem.ballPrefab.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().time;
            }
            else
            {
                GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

                foreach (GameObject ball in balls)
                {
                    ball.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().time = normalTrailLength;
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (zeroG)
            {
                Physics.gravity = gravity;
                zeroG = false;
            } else
            {
                gravity = Physics.gravity;
                Physics.gravity = Vector3.zero;
                zeroG = true;
            }
        }
    }
}
