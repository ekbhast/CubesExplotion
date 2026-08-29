using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private InputReader _inputReader;
    private LayerMask _cubeLayer;

    public event Action<Cube> CubeHit;
    
    public void Initialize(InputReader inputReader, LayerMask cubeLayer)
    {
        _inputReader = inputReader;
        _cubeLayer = cubeLayer;

        SubscribeToMouseClick();
    }

    private void OnDestroy()
    {
        UnSubscribeToMouseClick();
    }

    private void SubscribeToMouseClick()
    {
       _inputReader.Clicked += Raycast;
    }

    private void UnSubscribeToMouseClick()
    {
        _inputReader.Clicked -= Raycast;
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _cubeLayer))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}
