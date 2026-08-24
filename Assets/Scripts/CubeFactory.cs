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
    
    public List<Cube> Create(CubeCreateData data, int cubeCount)
    {
        List<Cube> cubes = new();
        Vector3 cubePosition = data.Position; 

        for (int i = 0; i < cubeCount; i++)
        {
            Cube cube = Object.Instantiate(_prefab);

            cube.transform.position = cubePosition;
            cube.transform.localScale = data.Scale;

            cubes.Add(cube);
            
            cubePosition += new Vector3(0.6f, 2f, 0);
        }

        return cubes;
    }
}
