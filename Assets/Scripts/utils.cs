using System;
using UnityEngine;

public class Utils
{
    private static readonly System.Random s_random = new System.Random();

    public static int GenerateRundomNumber(int min, int max)
    {
        return s_random.Next(min, max);
    }

    public static float GenerateRandomFloat()
    {
        return (float)s_random.NextDouble();
    }

    public static Color GenerateRandomColor()
    {
        return new Color(
            GenerateRandomFloat(),
            GenerateRandomFloat(),
            GenerateRandomFloat()
        );
    }
}