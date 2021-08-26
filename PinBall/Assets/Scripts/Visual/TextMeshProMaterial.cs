using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshProMaterial : MonoBehaviour
{
    public Material faceMaterial;
    public MaterialChannel faceMaterialChannel;
    public Material outlineMaterial;
    public MaterialChannel outlineMaterialChannel;

    private Font font;
    public List<MeshFilter> mPlaneFilters;

    private void Awake()
    {
        
    }
}

public enum MaterialChannel
{
    BaseColor,
    Emission
}