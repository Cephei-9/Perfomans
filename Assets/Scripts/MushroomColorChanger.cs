using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MushroomColorChanger : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private float _intensity = 1;
    [Range(0, 100)]
    [SerializeField] private float _addIntensityPercent = 0;

    [SerializeField] private Gradient _gradient;
    [SerializeField] private Material _material;

    [SerializeField] private Renderer[] _mushrooms;

    private void OnValidate()
    {
        ChangeMushroomIntensity();
    }

    [ContextMenu("ChangeToRandomColor")]
    public void ChangeToRandomColor()
    {
        foreach (var item in _mushrooms)
        {
            Color newColor = _gradient.Evaluate(Random.value);
            item.material.color = StaticMethods.ClampedColor(newColor, 0.7f, 1); 
            item.material.SetColor("_EmissionColor", newColor * _intensity);
        }
    }

    [ContextMenu("ChangeToMaterial")]
    public void ChangeToMaterial()
    {
        foreach (var item in _mushrooms)
        {
            item.material = _material;
        }
    }

    public void ChangeToMaterial(Material material)
    {
        foreach (var item in _mushrooms)
        {
            item.material = material;
        }
    }

    [ContextMenu("ChangeIntensity")]
    public void ChangeMushroomIntensity()
    {
        ChangeIntensity(_intensity);
    }

    public void ChangeMushroomIntensity(float intensity)
    {
        float resaultIntensity = intensity + (intensity + (intensity * _addIntensityPercent / 100));
        ChangeIntensity(resaultIntensity);
    }

    private void ChangeIntensity(float intensity)
    {
        foreach (var item in _mushrooms)
        {
            Color color = item.material.GetColor("_EmissionColor");
            color = StaticMethods.NormolizeColor(color);
            item.material.color = StaticMethods.ClampedColor(color, 0.7f, 1); ;
            item.material.SetColor("_EmissionColor", color * intensity);
        }
    }
}
