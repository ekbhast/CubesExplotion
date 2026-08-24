using System;
using UnityEngine;
public class Cube : MonoBehaviour
{
    private Color _color;
    private Vector3 _position;
    private Vector3 _scale;
    private float _splitChance;

    public event Action<Cube> Clicked;

    public Color Color => _color;
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
        _color = color;
        _splitChance = splitChance;

        transform.position = _position;
        transform.localScale = _scale;
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
    }
}   
