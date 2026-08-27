using System.Collections.Generic;
using UnityEngine;

public class CubeFactory
{   
    private Cube _cubePrefab;
    
    public CubeFactory(Cube cubePrefab)
    {
        _cubePrefab = cubePrefab;
    } 

    public List<Cube> Create(Vector3 position,int cubeCount, Vector3 scale, float splitChance)
    {
        List<Cube> cubes = new();

        for (int i = 0; i < cubeCount; i++)
        {
            Cube cube = Object.Instantiate(_cubePrefab);
            cube.gameObject.SetActive(false);
            cube.gameObject.layer = LayerMask.NameToLayer("Cube");

            cubes.Add(cube);

            cubes[i].Initialize(
                position,
                scale,
                Random.ColorHSV(),
                splitChance 
            );
        }

        return cubes;
    }
}
