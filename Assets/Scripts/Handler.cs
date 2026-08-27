using UnityEngine;
using System.Collections.Generic;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    private CubeFactory _factory;
    private float _maxSplitChance = 1f;
    private float _minSplitChance = 0f;
    private float _minSplitCubeValue = 2f;
    private float _maxSplitCubeValue = 6f;

    public void Start()
    {
        SubscribeCubeHit();
    }

    public void Initialize(CubeFactory factory)
    {
        _factory = factory;
    }

    public void SubscribeCubeHit()
    {
        _raycaster.CubeHit += TrySplitCube;
    }

    private void TrySplitCube(Cube cube)
    {
        bool shouldSplit = Random.Range(_minSplitChance, _maxSplitChance) <= cube.SplitChance;

        _spawner.DestroyCube(cube);

        if (shouldSplit)
        {
            List<Cube> cubes = SplitCube(cube);
            _spawner.Spawn(cubes);
        }
    }

    private List<Cube> SplitCube(Cube cube)
    {
            Vector3 scale = cube.Scale / 2;
            Vector3 explotionPosition = cube.transform.position;
            float splitChance = cube.SplitChance / 2;
            int cubeCount = Random.Range((int)_minSplitCubeValue, (int)_maxSplitCubeValue + 1);

            List<Cube> cubes = _factory.Create(explotionPosition, cubeCount, scale, splitChance);

            return cubes;
    }
}