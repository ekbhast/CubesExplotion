using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory
{   
    private Cube _prefab;

    public CubeFactory(Cube prefab)
    {
        _prefab = prefab;
    }
    
    public List<Cube> Create(int cubeCount, Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        List<Cube> cubes = new();

        for (int i = 0; i < cubeCount; i++)
        {
            Cube cube = Object.Instantiate(_prefab);
            cube.Initialize(
                position,
                scale,
                color,
                splitChance
            );

            cubes.Add(cube);
        }

        return cubes;
    }
}
