using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    public GameObject effectEmitter;
    private VisualEffect effect;

    void Awake()
    {
        effect = effectEmitter.GetComponent<VisualEffect>();
    }

    public virtual void PlayParticle()
    {
        effect.Play();
    }

    public virtual void StopParticle()
    {
        effect.Stop();
    }
}
