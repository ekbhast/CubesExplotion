using UnityEngine;
using System.Collections.Generic;

public class Splitter : MonoBehaviour
{
    private CubeFactory _factory;
    private float _minSplitCubeValue = 2f;
    private float _maxSplitCubeValue = 6f;

    public void Initialize(CubeFactory factory)
    {
        _factory = factory;
    }

    public List<Cube> Split(Cube cube)
    {
        Vector3 scale = cube.Scale / 2;
        Vector3 explotionPosition = cube.transform.position;
        float splitChance = cube.SplitChance / 2;
        int cubeCount = Random.Range((int)_minSplitCubeValue, (int)_maxSplitCubeValue + 1);

        List<Cube> cubes = _factory.Create(explotionPosition, cubeCount, scale, splitChance);

        return cubes;
    }
}