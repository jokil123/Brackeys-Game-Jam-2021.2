using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DeathZone : MonoBehaviour
{
    public SpawnSystem spawnSystem;
    public HealthSystem healthSystem;
    public int damage = 10;

    public GameObject ParticleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject.Destroy(other.gameObject);

            if (ParticleEffect)
            {
                ParticleEffect.GetComponent<VisualEffect>().Play();
            }

            if (spawnSystem.gameIsRunning)
            {
                healthSystem.Health -= 100;
                spawnSystem.BallCount -= 1;
                spawnSystem.AddBallsToSpawn();
            }
        }
    }
}
 