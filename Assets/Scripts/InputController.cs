using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action Clicked;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
        }
    }
}
