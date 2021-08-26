using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SizeType
{
    Scale,
    BoxCollider,
    Plane
}

public class OutlineMarkings : MonoBehaviour
{
    public SizeType sizeType;

    public float heightoffset;
    public float offset;
    public float width;
    public Material material;

    Vector3 size;
    Vector3 position;
    List<GameObject> markings = new List<GameObject>();


    void Start()
    {
        size = GetOutlineSize();
        position = GetOutlinePosition();
        GenerateMarkings();
    }

    /*
    private void Update() // Disable when building
    {
        size = GetOutlineSize();
        position = GetOutlinePosition();
        GenerateMarkings();
    }
    */

    Vector3 GetOutlinePosition()
    {
        Vector3 position = Vector3.zero;
        switch (sizeType)
        {
            case SizeType.Scale:
                position = Vector3.zero;
                break;
            case SizeType.BoxCollider:
                position = gameObject.GetComponent<BoxCollider>().center;
                break;
            case SizeType.Plane:
                position = Vector3.zero;
                break;
        }

        return position;
    }

    Vector3 GetOutlineSize()
    {
        Vector3 size = Vector3.zero;
        switch (sizeType)
        {
            case SizeType.Scale:
                size = gameObject.transform.localScale;
                break;
            case SizeType.BoxCollider:
                size = gameObject.GetComponent<BoxCollider>().size;
                break;
            case SizeType.Plane:
                size.x = gameObject.transform.localScale.x * 10;
                size.y = 1;
                size.z = gameObject.transform.localScale.z * 10;
                break;
        }

        return size;
    }


    void GenerateMarkings()
    {
        foreach (GameObject item in markings)
        {
            Destroy(item);
        }
        markings.Clear();

        for (int i = 2; i < 6; i++)
        {
            markings.Add(GenerateMarker(Utility.directions[i]));
        }
    }

    GameObject GenerateMarker(Vector3 markerDirection)
    {
        Vector3 width3 = new Vector3(width, width, width);
        Vector3 offset3 = new Vector3(offset, offset, offset);

        GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Plane);
        marker.transform.position = gameObject.transform.position;
        marker.transform.localScale = size / 10;

        Vector3 markerScale = marker.transform.localScale;
        markerScale += width3 / 10 + (offset3 / 10) * 2;
        markerScale = Utility.VectorMask(width3 / 10, markerScale, markerDirection);

        Vector3 markerPosition = marker.transform.position;
        markerPosition += Utility.VectorDirectMultiply(size / 2 + offset3, markerDirection) + position;
        markerPosition.y += -size.y/2 + heightoffset;

        marker.transform.position = markerPosition;

        marker.transform.localScale = markerScale;

        marker.GetComponent<MeshRenderer>().material = material;

        return marker;
    }


    private void OnDrawGizmos()
    {
        size = GetOutlineSize();

        for (int i = 2; i < 6; i++)
        {
            GenerateGizmo(Utility.directions[i]);
            position = GetOutlinePosition();
        }
    }

    void GenerateGizmo(Vector3 gizmoDirection)
    {
        Vector3 width3 = new Vector3(width, width, width);
        Vector3 offset3 = new Vector3(offset, offset, offset);

        Vector3 gizmoCenter;
        Vector3 gizmoSize;

        gizmoCenter = gameObject.transform.position;
        gizmoSize = size;

        gizmoSize += width3 + (offset3) * 2;
        gizmoSize = Utility.VectorMask(width3, gizmoSize, gizmoDirection);
        gizmoSize.y = 0.01f;

        gizmoCenter += Utility.VectorDirectMultiply(size / 2 + offset3, gizmoDirection) + position;
        gizmoCenter.y += -size.y / 2 + heightoffset;

        Gizmos.color = new Color(1, 1, 0, 1f);
        Gizmos.DrawCube(gizmoCenter, gizmoSize);
    }
}