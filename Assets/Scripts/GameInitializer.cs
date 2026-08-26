using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Spawner _spawner;

    private CubeFactory _factory;

    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Vector3 _startPosition = new Vector3(0, 5f, 0);

    private float _startSplitChance = 1f;
    // private float _minSplitCubeValue = 2f;
    // private float _maxSplitCubeValue = 6f;

    void Start()
    {
        _factory = new CubeFactory(_cubePrefab);        

        List<Cube> cubes = _factory.Create(
            _startPosition,
            _cubeCount,
            _startScale,
            _startSplitChance
            );

        _spawner.Spawn(cubes, true);
    }

    // private void TrySplitCube(Cube cube)
    // {
    //     bool shouldSplit = Random.Range(0f, 1f) <= cube.SplitChance;

    //     if (shouldSplit)
    //     {
    //         Vector3 scale = cube.Scale / 2;
    //         Vector3 explotionPosition = cube.transform.position;
    //         float splitChance = cube.SplitChance / 2;
    //         int cubeCount = Random.Range((int)MinSplitCubeValue, (int)MaxSplitCubeValue + 1);

    //         List<Vector3> cubePositions = GenerateCubePositions(cube.transform.position, scale, cubeCount);
    //         List<Cube> cubes = _factory.Create(cubePositions, scale, splitChance);

    //        ApplyExplosionForce(cubes, explotionPosition);
    //     }
    // }



    // private void DestroyCube(Cube cube)
    // {
    //     Destroy(cube.gameObject);
    // }

    // private void ApplyExplosionForce(
    // List<Cube> cubes,
    // Vector3 explosionPosition)
    // {
    //     foreach (Cube newCube in cubes)
    //     {

    //         Vector3 direction =
    //             newCube.transform.position - explosionPosition;

    //         direction.Normalize();

    //         Rigidbody rigidbody =
    //             newCube.GetComponent<Rigidbody>();

    //         rigidbody.AddForce(
    //             direction * _force,
    //             ForceMode.Impulse
    //         );
    //     }
    // }

    // private List<Vector3> GenerateCubePositions(
    //     Vector3 center,
    //     Vector3 scale,
    //     int cubeCount)
    // {
    //     List<Vector3> positions = new();

    //     float spacing = scale.x + 0.1f;

    //     int sizeX = Mathf.CeilToInt(Mathf.Pow(cubeCount, 1f / 3f));
    //     int sizeY = sizeX;
    //     int sizeZ = Mathf.CeilToInt((float)cubeCount / (sizeX * sizeY));

    //     for (int i = 0; i < cubeCount; i++)
    //     {
    //         int x = i % sizeX;
    //         int y = (i / sizeX) % sizeY;
    //         int z = i / (sizeX * sizeY);

    //         float offsetX = (x - (sizeX - 1) / 2f) * spacing;
    //         float offsetY = (y - (sizeY - 1) / 2f) * spacing;
    //         float offsetZ = (z - (sizeZ - 1) / 2f) * spacing;

    //         positions.Add(
    //             center + new Vector3(
    //                 offsetX,
    //                 offsetY,
    //                 offsetZ
    //             )
    //         );
    //     }

    //     return positions;
    // }
}