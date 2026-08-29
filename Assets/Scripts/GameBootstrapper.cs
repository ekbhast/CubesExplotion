using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CubeHitHandler _cubeHitHandler;
    [SerializeField] private Splitter _splitter;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _cubeLayer;



    private CubeFactory _factory;
    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Vector3 _startPosition = new Vector3(0, 5f, 0);
    private float _startSplitChance = 1f;

    public void Start()
    {
        _factory = new CubeFactory(_cubePrefab);
        _cubeHitHandler.Initialize(_splitter, _spawner, _raycaster);
        _splitter.Initialize(_factory);
        _raycaster.Initialize(_inputReader, _cubeLayer);              

        List<Cube> cubes = _factory.Create(
            _startPosition,
            _cubeCount,
            _startScale,
            _startSplitChance
            );

        _spawner.Spawn(cubes, true);
    }
}