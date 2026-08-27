using UnityEngine;
using System.Collections.Generic;

public class Handler : MonoBehaviour
{
    private Raycaster _raycaster;
    private Spawner _spawner;
    private Splitter _splitter;
    private float _maxSplitChance = 1f;
    private float _minSplitChance = 0f;
    private Exploder _exploder = new();

    public void Start()
    {
        SubscribeCubeHit();
    }

    public void Initialize(Splitter splitter, Spawner spawner, Raycaster raycaster)
    {
        _splitter = splitter;
        _spawner = spawner;
        _raycaster = raycaster;
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
            List<Cube> cubes = _splitter.Split(cube);
            _spawner.Spawn(cubes);
            _exploder.Explode(cubes, cube);
        }
    }


}