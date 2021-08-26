using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public SpawnSystem spawnSystem;
    public HealthSystem healthSystem;
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject.Destroy(other.gameObject);
            healthSystem.Health -= 10;
            spawnSystem.ballCount -= 1;
            spawnSystem.AddBallsToSpawn();
        }
    }
}
 