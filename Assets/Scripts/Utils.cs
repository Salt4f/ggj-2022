using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utils
{
    static private System.Random random = new System.Random();

    static public double getRandomDouble(double min, double max)
    {
        return (double)random.NextDouble() * (max - min) + min;
    }

    static public float getRandomFloat(float min, float max)
    {
        return (float)random.NextDouble() * (max - min) + min;
    }


    // -------------------

    static public Vector3 getNextPosition(Transform currentTransform, float distance)
    {
        float nextAngle = Utils.getRandomFloat(10.0f, 40.0f);
        float front = Mathf.Acos((Mathf.PI / 180) * nextAngle);
        float side = Mathf.Asin((Mathf.PI / 180) * nextAngle);
        float x = Utils.getRandomFloat(0, 1) > 0.5f ? 1.0f : -1.0f;

        Vector3 nextDirection = (currentTransform.forward * front + x * currentTransform.right * side).normalized;

        return currentTransform.position + nextDirection * distance;

    }

    static public Vector3 XZPlane(this Vector3 vector3)
    {
        return new Vector3(vector3.x, 0.0f, vector3.z);
    }
}
