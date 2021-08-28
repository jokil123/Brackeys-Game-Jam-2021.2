using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System.Linq;

public class BouncePad : TriggerPad
{
    [Header("Score")]
    public bool giveScore = true;
    private int scoreAmount = 10;
    private ScoreSystem scoreSystem;
    private SpawnSystem spawnSystem;

    public Vector3 bounceDirection;
    public float bounceStrengthMultiplier;
    public BounceType bounceType;

    public VisualEffect particleEffect;

    public override void TriggerAction(List<GameObject> bounceObjects)
    {
        if (triggerEnabled)
        {
            lastTriggered = Time.time;

            


            foreach (GameObject bounceObject in bounceObjects)
            {
                Vector3 launchVector = GetLaunchVector(bounceObject);

                Rigidbody bounceRigidbody = bounceObject.GetComponent<Rigidbody>();

                bounceObject.GetComponent<Rigidbody>().AddForce(launchVector);

                if (giveScore)
                {
                    scoreSystem.Score += scoreAmount;
                }

                if (particleEffect)
                {
                    // Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + launchVector, Color.blue, 1);

                    particleEffect.SetVector3("Direction", bounceRigidbody.velocity);
                    particleEffect.Play();
                }
            }
        }
    }

    Vector3 GetLaunchVector(GameObject bounceObject)
    {
        Vector3 bounceDireciton = Vector3.zero;

        switch (bounceType)
        {
            case BounceType.directional:
                bounceDireciton = gameObject.transform.rotation * bounceDirection;
                break;
            case BounceType.radial:
                bounceDireciton = bounceObject.transform.position - gameObject.transform.position;

                break;
            case BounceType.reflect:

                break;
            case BounceType.random:
                bounceDireciton = Random.insideUnitSphere;
                break;
        }



        return bounceDireciton.normalized * bounceStrengthMultiplier;
    }

    private void OnDrawGizmos()
    {
        if (bounceType == BounceType.directional)
        {
            Vector3 start = gameObject.transform.position;
            Vector3 end = start + GetLaunchVector(gameObject) * Config.GizmoVectorLengthMultiplier; // Oof, very dirty code right here
            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
        }
    }

    private void Start()
    {
        GameObject gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        scoreSystem = gameMaster.GetComponent<ScoreSystem>();
        spawnSystem = gameMaster.GetComponent<SpawnSystem>();
    }
}

public enum BounceType
{
    directional,
    radial,
    reflect,
    random
}