using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private float _force = 5f;

    public void ExplodeAfterSplitCubes(
        List<Cube> cubes,
        Cube cube)
    {
        Vector3 explosionPosition = cube.transform.position;

        foreach (Cube newCube in cubes)
        {
            Vector3 direction = newCube.transform.position - explosionPosition;

            direction.Normalize();

            newCube.Rigidbody.AddForce(
                direction * _force,
                ForceMode.Impulse
            );
        }
    }
}
