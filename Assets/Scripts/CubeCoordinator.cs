using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int _cubeCount;
    [SerializeField] private Cube _cubePrefab;

    private Vector3 _startPosition = new Vector3(0, 0.5f, 0);
    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Color _startColor = Color.white;
    private float _startSplitChance = 1f;


      void Start()
    {
        CubeFactory factory = new CubeFactory(_cubePrefab);
        factory.Create(_cubeCount, _startPosition, _startScale, _startColor, _startSplitChance);
    }
}
