using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnTime = 0.4f;

    private Shifter _shifter = new();
    private WaitForSeconds _waitTime;

    public void Awake()
    {
        _waitTime = new WaitForSeconds(_startSpawnTime);
    }

    public void Spawn(List<Cube> cubes, bool isStart = false)
    {
        if (isStart)
        {
        StartCoroutine(SpawnCoroutine(cubes));
        } 
        else
        {
            foreach (Cube cube in cubes)
            {
                cube.transform.localScale = cube.Scale;
                cube.gameObject.SetActive(true); 
            }
        }
    }

    private IEnumerator SpawnCoroutine(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            _shifter.ShiftStartPosition(cube);
            cube.gameObject.SetActive(true);  

            yield return _waitTime;
        }
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
