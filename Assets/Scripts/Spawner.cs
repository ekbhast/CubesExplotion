using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.transform.position = cube.Position;
            cube.transform.localScale = cube.Scale;
        }
    }
}
