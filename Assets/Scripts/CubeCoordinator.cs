using System.Collections.Generic;
using UnityEngine;

public class CubeCoordinator : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;

    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Color _startColor = Color.white;
    private float _startSplitChance = 1f;
    private List<Vector3> _startCubePositions = new();
    private CubeFactory _factory;
    private int MaxCubeValue = 20;
    private int MinCubeValue = 10;
    private float _force = 10f;


    void Start()
    {
        float shiftY = 1.5f;

        _factory = new CubeFactory(_cubePrefab);

        for(int i = 0; i < _cubeCount; i++)
        {   
            _startCubePositions.Add(new Vector3(Utils.GenerateRundomNumber(-2, 2), shiftY, Utils.GenerateRundomNumber(-2, 2)));
            shiftY += 1.5f;
        }

        List<Cube> cubes = _factory.Create(
            _startCubePositions,
            _startScale,
            _startSplitChance
            );

        foreach(Cube cube in cubes)
        {
            SubscribeToClick(cube);
        }
    }

    private void HandleCubeClick(Cube cube)
    {
        TrySplitCube(cube);
        DestroyCube(cube);
    }

    private void TrySplitCube(Cube cube)
    {
        bool shouldSplit = Utils.GenerateRandomFloat() <= cube.SplitChance;

        if (shouldSplit)
        {
            Vector3 scale = cube.Scale / 2;
            Vector3 explotionPosition = cube.transform.position;
            float splitChance = cube.SplitChance / 2;
            int cubeCount = Utils.GenerateRundomNumber(MinCubeValue, MaxCubeValue + 1);

            List<Vector3> cubePositions = GenerateCubePositions(cube.transform.position, scale, cubeCount);
            List<Cube> cubes = _factory.Create(cubePositions, scale, splitChance);

           ApplyExplosionForce(cubes, explotionPosition);
        }
    }

    private void SubscribeToClick(Cube cube)
    {
        cube.Clicked += HandleCubeClick;
    }

    private void UnsubscribeToClick(Cube cube)
    {
        cube.Clicked -= HandleCubeClick;
    }

    private void DestroyCube(Cube cube)
    {
        UnsubscribeToClick(cube);
        Destroy(cube.gameObject);
    }

    private void ApplyExplosionForce(
    List<Cube> cubes,
    Vector3 explosionPosition)
    {
        foreach (Cube newCube in cubes)
        {
            SubscribeToClick(newCube);

            Vector3 direction =
                newCube.transform.position - explosionPosition;

            direction.Normalize();

            Rigidbody rigidbody =
                newCube.GetComponent<Rigidbody>();

            rigidbody.AddForce(
                direction * _force,
                ForceMode.Impulse
            );
        }
    }

    //То что написанно ниже, написалай нейронка, слишком сложно для меня пока, хоть я и понимаю,
    //что тут происходит

    private List<Vector3> GenerateCubePositions(
        Vector3 center,
        Vector3 scale,
        int cubeCount)
    {
        List<Vector3> positions = new();

        float spacing = scale.x + 0.1f;

        int sizeX = Mathf.CeilToInt(Mathf.Pow(cubeCount, 1f / 3f));
        int sizeY = sizeX;
        int sizeZ = Mathf.CeilToInt((float)cubeCount / (sizeX * sizeY));

        for (int i = 0; i < cubeCount; i++)
        {
            int x = i % sizeX;
            int y = (i / sizeX) % sizeY;
            int z = i / (sizeX * sizeY);

            float offsetX = (x - (sizeX - 1) / 2f) * spacing;
            float offsetY = (y - (sizeY - 1) / 2f) * spacing;
            float offsetZ = (z - (sizeZ - 1) / 2f) * spacing;

            positions.Add(
                center + new Vector3(
                    offsetX,
                    offsetY,
                    offsetZ
                )
            );
        }

        return positions;
    }
}