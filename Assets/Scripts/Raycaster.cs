using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHit;
    
    void Start()
    {
        SubscribeToMouseCkick();
    }

    private void SubscribeToMouseCkick()
    {
       _inputReader.Clicked += Raycast;
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Cube cube = hit.collider.GetComponent<Cube>();
            if (cube != null)
            {
               CubeHit?.Invoke(cube); 
            }
        }
    }
}
