using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsGroupManager : MonoBehaviour
{
    [SerializeField] private MushroomColorChanger[] _mushroomGroups;

    [Range(0, 6)]
    [SerializeField] private float _mainIntensity = 1;
    [Space]

    public Material _mainMaterial;

    private void OnValidate()
    {
        ChangeIntensity();
    }

    [ContextMenu("ChangeToRandomColor")]
    public void ChangeToRandomColor()
    {
        foreach (var item in _mushroomGroups)
        {
            item.ChangeToRandomColor();
            item.ChangeMushroomIntensity(_mainIntensity);
        }
    }

    [ContextMenu("ChangeIntensity")]
    public void ChangeIntensity()
    {
        foreach (var item in _mushroomGroups)
        {
            _mainIntensity = Mathf.Max(0.1f, _mainIntensity);
            item.ChangeMushroomIntensity(_mainIntensity);
        }
    }

    [ContextMenu("SatCommonMaterial")]
    public void SatCommonMaterial()
    {
        foreach (var item in _mushroomGroups)
        {
            item.ChangeToMaterial(_mainMaterial);
        }
    }
}
