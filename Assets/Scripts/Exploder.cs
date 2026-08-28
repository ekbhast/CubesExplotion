using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class Exploder
    {
    private float _force = 5f;
    private float _radius = 2f;

    public void ExplodeAfterSplitCubes(
        List<Cube> cubes,
        Cube cube)
    {
        Vector3 explosionPosition = cube.transform.position;

        foreach (Cube newCube in cubes)
        {
            Vector3 direction = newCube.transform.position - explosionPosition;

            direction.Normalize();

            newCube.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }

    public void ExplodeAfterDestroyCube(Cube cube)
    {
        Vector3 explosionPosition = cube.transform.position;
        Collider[] objects = Physics.OverlapSphere(explosionPosition, _radius);

        foreach (Collider pushedObject in objects)
        {
            Rigidbody rigidbody = pushedObject.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(10f, explosionPosition, _radius, 0f, ForceMode.Impulse);
            }
        }
    }
}
