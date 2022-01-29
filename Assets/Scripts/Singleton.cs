using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    static private System.Random random = new System.Random();

    static public Vector3 getPlayerPos()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    static public double getRandomDouble(double min, double max)
    {
        return (double)random.NextDouble() * (max - min) + min;
    }

    static public float getRandomFloat(float min, float max)
    {
        return (float)random.NextDouble() * (max - min) + min;
    }
}
