using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSceneSpawner : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;

      void Start()
    {
        CubeFactory factory = new CubeFactory(_cubePrefab);

        CubeCreateData data = new CubeCreateData(
            Color.white,
            new Vector3(0, 0, 0),
            Vector3.one,
            1f
        );

        factory.Create(data, _cubeCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
