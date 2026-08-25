using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action Clicked;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
            Debug.Log("Жмакнули мышкой");
        }
    }
}
