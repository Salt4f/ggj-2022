using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utils
{
    static private System.Random random = new System.Random();

    static public double GetRandomDouble(double min, double max)
    {
        return (double)random.NextDouble() * (max - min) + min;
    }

    static public float GetRandomFloat(float min, float max)
    {
        return (float)random.NextDouble() * (max - min) + min;
    }


    // -------------------

    static public Vector3 XZPlane(this Vector3 vector3)
    {
        return new Vector3(vector3.x, 0.0f, vector3.z);
    }
}
