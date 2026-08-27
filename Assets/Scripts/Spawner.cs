using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnTime = 0.4f;

    private float _minShift = -2f;
    private float _maxShift = 2f;

    public void Spawn(List<Cube> cubes, bool start = false)
    {
       StartCoroutine(SpawnCoroutine(cubes, start));
    }

    private IEnumerator SpawnCoroutine(List<Cube> cubes, bool start)
    {
        foreach (Cube cube in cubes)
        {
            if (start)
            {
                cube.transform.position = cube.Position + new Vector3(
                Random.Range(_minShift, _maxShift + 1), 
                Random.Range(_minShift, _maxShift+1), 
                Random.Range(_minShift, _maxShift + 1));

                yield return new WaitForSeconds(_startSpawnTime);
            }
            else
            {
                cube.transform.position = cube.Position;
            }

            cube.transform.localScale = cube.Scale;
            cube.gameObject.SetActive(true);  
        }
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
