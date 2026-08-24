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
    
    public List<Cube> Create(int cubeCount)
    {
        List<Cube> cubes = new();

        Vector3 cubePosition = new Vector3(0, 1, 0);
        Vector3 cubeScale = Vector3.one;

        for (int i = 0; i < cubeCount; i++)
        {
            Cube cube = Object.Instantiate(_prefab);

            cube.transform.position = cubePosition;
            cube.transform.localScale = cubeScale;

            cubes.Add(cube);

            cubePosition += new Vector3(0.6f, 2f, 0);
        }

        return cubes;
    }
}
