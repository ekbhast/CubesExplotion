using System.Collections.Generic;
using UnityEngine;

public class CubeFactory
{   
    private Cube _prefab;

    public CubeFactory(Cube prefab)
    {
        _prefab = prefab;
    }
    
    public List<Cube> Create(List<Vector3> cubePositions, Vector3 scale, float splitChance)
    {
        List<Cube> cubes = new();

        foreach (Vector3 cubePosition in cubePositions)
        {
            Cube cube = Object.Instantiate(_prefab);
            cube.Initialize(
                cubePosition,
                scale,
                Utils.GenerateRandomColor(),
                splitChance 
            );

            cubes.Add(cube);
        }

        return cubes;
    }
}
