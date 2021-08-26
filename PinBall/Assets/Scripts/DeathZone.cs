using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public HealthSystem healthSystem;
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            GameObject.Destroy(other);
            healthSystem.Health -= 10;
        }
    }
}
 