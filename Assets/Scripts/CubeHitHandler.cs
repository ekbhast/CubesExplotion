using UnityEngine;
using System.Collections.Generic;

public class CubeHitHandler : MonoBehaviour
{
    private Raycaster _raycaster;
    private Spawner _spawner;
    private Splitter _splitter;
    private float _maxSplitChance = 1f;
    private float _minSplitChance = 0f;
    private Exploder _exploder = new();

    public void Oestroy()
    {
        UnSubcribeCubeHit();
    }

    public void Initialize(Splitter splitter, Spawner spawner, Raycaster raycaster)
    {
        _splitter = splitter;
        _spawner = spawner;
        _raycaster = raycaster;

        SubscribeCubeHit();
    }

    public void SubscribeCubeHit()
    {
        _raycaster.CubeHit += TrySplitCube;
    }

    public void UnSubcribeCubeHit()
    {
        _raycaster.CubeHit -= TrySplitCube;
    }

    private void TrySplitCube(Cube cube)
    {
        bool isShouldSplit = Random.Range(_minSplitChance, _maxSplitChance) <= cube.SplitChance;
        _spawner.DestroyCube(cube);

        if (isShouldSplit)
        {
            List<Cube> cubes = _splitter.Split(cube);
            _spawner.Spawn(cubes);
            _exploder.ExplodeAfterSplitCubes(cubes, cube);
        }
        else
        {
            _exploder.ExplodeAfterDestroyCube(cube);
        }
    }
}