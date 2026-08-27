using System.Collections.Generic;
using UnityEngine;

public class Shifter
{
    private float _minShift = -2f;
    private float _maxShift = 2f;
    private float _spacingValue = 0.01f;

    public Cube ShiftStartPosition(Cube cube)
    {
        cube.transform.position  = cube.Position + new Vector3(
            Random.Range(_minShift, _maxShift + 1), 
            Random.Range(_minShift, _maxShift+1), 
            Random.Range(_minShift, _maxShift + 1));
        
        return cube;
    }

    public void ShiftSplitCubePositions(
        List<Cube> cubes,
        Vector3 explosionCenter,
        Vector3 scale)
    {
        float spacing = scale.x + _spacingValue;
        int columnsPerRow = 3;

        for (int i = 0; i < cubes.Count; i++)
        {
            int column = i % columnsPerRow;
            int row = i / columnsPerRow;

            Vector3 offset = new Vector3(
                (column - 1) * spacing,
                row * spacing,
                0
            );

            cubes[i].transform.position = explosionCenter + offset;
        }
    }
}