using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Vector3 _position;
    private Vector3 _scale;
    private float _splitChance;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Vector3 Position => _position;
    public Vector3 Scale => _scale;
    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    public void Initialize(
        Vector3 position,
        Vector3 scale,
        Color color,
        float splitChance)
    {
        _position = position;
        _scale = scale;
        _splitChance = splitChance;

        _renderer.material.color = color;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}   
