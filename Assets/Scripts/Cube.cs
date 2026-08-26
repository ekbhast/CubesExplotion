using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 _position;
    private Vector3 _scale;
    private float _splitChance;

    public Vector3 Position => _position;
    public Vector3 Scale => _scale;
    public float SplitChance => _splitChance;

    public void Initialize(
        Vector3 position,
        Vector3 scale,
        Color color,
        float splitChance)
    {
        _position = position;
        _scale = scale;
        _splitChance = splitChance;

        transform.position = _position;
        transform.localScale = _scale;

        GetComponent<Renderer>().material.color = color;
    }
}   
