using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnTime = 0.4f;
    private Shifter _shifter = new Shifter();  

    public void Spawn(List<Cube> cubes, bool start = false)
    {
        if (start)
        {
        StartCoroutine(SpawnCoroutine(cubes));
        } 
        else
        {
            foreach (Cube cube in cubes)
            {
                cube.transform.position = cube.Position;
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

            yield return new WaitForSeconds(_startSpawnTime);
        }
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
