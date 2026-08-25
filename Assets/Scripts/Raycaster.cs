using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    void Start()
    {
        SubscribeToMouseCkick();
    }

    void Update()
    {
        
    }

    private void SubscribeToMouseCkick()
    {
       _inputController.Clicked += Raycast;
    }

    private void Raycast()
    {
        Debug.Log("Рэйкст сработал");
    }

}
