using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static readonly Vector3[] directions = { Vector3.up, Vector3.down, Vector3.right, Vector3.left, Vector3.forward, Vector3.back};

    // And so begins the 2½D pain

    public static Vector3 V2toV3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    public static Vector2 V3toV2(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    public static void LineRel(GameObject transformGameObject, Vector3 vector, Color color)
    {
        Debug.DrawLine(transformGameObject.transform.position, transformGameObject.transform.position + vector, color, Time.deltaTime, false);
    }

    public static Vector3 VectorDirectMultiply(Vector3 a, Vector3 b)
    {
        float x = a.x * b.x;
        float y = a.y * b.y;
        float z = a.z * b.z;

        return new Vector3(x, y, z);
    }

    public static Vector3 VectorMask(Vector3 topLayer, Vector3 bottomLayer, Vector3 MaskLayer)
    {
        Vector3 output = Vector3.zero;

        for (int i = 0; i < 3; i++)
        {
            if (MaskLayer[i] == 1)
            {
                output[i] = topLayer[i];
            }
            else if (MaskLayer[i] == -1)
            {
                output[i] = -topLayer[i];
            }
            else
            {
                output[i] = bottomLayer[i];
            }
        }

        return output;
    }
}