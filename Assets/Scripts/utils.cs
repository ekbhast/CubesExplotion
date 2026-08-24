using System;

public class Utils
{
    private static readonly Random s_random = new Random();

    public static int GenerateRundomNumber(int min, int max)
    {
        return s_random.Next(min, max);
    }
}