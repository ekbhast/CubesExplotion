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

    void Start()
    {
        CubeFactory factory = new CubeFactory(_cubePrefab);
        float shiftY = 1.5f;

        for(int i = 0; i < _cubeCount; i++)
        {   
            _startCubePositions.Add(new Vector3(Utils.GenerateRundomNumber(-2, 2), shiftY, Utils.GenerateRundomNumber(-2, 2)));
            shiftY += 1.5f;
        }

        List<Cube> cubes = factory.Create(
            _startCubePositions,
            _startScale,
            _startColor,
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
        Debug.Log("Чпоньк");
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
}