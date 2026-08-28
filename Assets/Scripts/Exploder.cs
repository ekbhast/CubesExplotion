using System.Collections.Generic;
using UnityEngine;

    public class Exploder
    {
    private float _force = 2f;
    private float _radius = 1f;

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
        float explosionForceByScale = _force/cube.Scale.x;
        float explosionRadiudByScle = _radius/cube.Scale.x;

        Vector3 explosionPosition = cube.transform.position;
        Collider[] objects = Physics.OverlapSphere(explosionPosition, _radius);

        foreach (Collider pushedObject in objects)
        {
            Rigidbody rigidbody = pushedObject.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForceByScale, explosionPosition, explosionRadiudByScle, 0f, ForceMode.Impulse);
            }
        }
    }
}
