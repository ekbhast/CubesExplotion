using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Color _color;
    private Vector3 _position;
    private Vector3 _scale;
    private float _splitChance;

    public Color Color => _color;
    public Vector3 Position => _position;
    public Vector3 Scale => _scale;
    public float SplitChance => _splitChance;

    public void Initialize(Cube data)
    {
        _color = data.Color;
        _position = data.Position;
        _scale = data.Scale;
        _splitChance = data.SplitChance;

        transform.position = _position;
        transform.localScale = _scale;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}   
