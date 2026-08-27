using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Shifter
{
    private float _minShift = -2f;
    private float _maxShift = 2f;

    public Cube ShiftStartPosition(Cube cube)
    {
        cube.transform.position  = cube.Position + new Vector3(
            Random.Range(_minShift, _maxShift + 1), 
            Random.Range(_minShift, _maxShift+1), 
            Random.Range(_minShift, _maxShift + 1));
        
        return cube;
    }
}