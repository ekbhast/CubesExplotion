using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnTime = 0.4f; 

    public void Spawn(List<Cube> cubes, bool start = false)
    {
       StartCoroutine(SpawnCoroutine(cubes, start));
    }

   private IEnumerator SpawnCoroutine(List<Cube> cubes, bool start)
    {
        foreach (Cube cube in cubes)
        {
            cube.transform.position = cube.Position;
            cube.transform.localScale = cube.Scale;
            cube.gameObject.SetActive(true);

            if (start)
                yield return new WaitForSeconds(_startSpawnTime);
        }
    }
}
