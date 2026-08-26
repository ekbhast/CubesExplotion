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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log(target);
        }
    }

}
