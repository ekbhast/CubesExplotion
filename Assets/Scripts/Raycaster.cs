using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private InputReader _inputReader;
    private LayerMask _cubeLayer;

    public event Action<Cube> CubeHit;
    
    void Start()
    {
        SubscribeToMouseCkick();
    }

    public void Initialize(InputReader inputReader, LayerMask cubeLayer)
    {
        _inputReader = inputReader;
        _cubeLayer = cubeLayer;
    }

    private void SubscribeToMouseCkick()
    {
       _inputReader.Clicked += Raycast;
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _cubeLayer))
        {
            Cube cube = hit.collider.GetComponent<Cube>();
            if (cube != null)
            {
               CubeHit?.Invoke(cube); 
            }
        }
    }
}
