using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreateData
{
 
    private Color _color;
    private Vector3 _position;
    private Vector3 _scale;
    private float _splitChance;

    public Color Color => _color;
    public Vector3 Position => _position;
    public Vector3 Scale => _scale;
    public float SplitChance => _splitChance;

    public CubeCreateData(Color color, Vector3 position, Vector3 scale, float splitChance)
    {
        _color = color;
        _position = position;
        _scale = scale;
        _splitChance = splitChance;
    }
}
