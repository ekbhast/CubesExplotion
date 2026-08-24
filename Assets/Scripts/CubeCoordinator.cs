using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;

      void Start()
    {
        CubeFactory factory = new CubeFactory(_cubePrefab);
        factory.Create(_cubeCount);
    }
}
