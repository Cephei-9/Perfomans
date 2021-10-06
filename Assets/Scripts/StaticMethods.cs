using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticMethods
{
    public static Color NormolizeColor(Color color)
    {
        float k = 1 / color.maxColorComponent;
        return color * k;
    }

    public static Color ClampedColor(Color color, float minValue, float maxValue)
    {
        color.r = Mathf.Clamp(color.r, minValue, maxValue);
        color.g = Mathf.Clamp(color.g, minValue, maxValue);
        color.b = Mathf.Clamp(color.b, minValue, maxValue);
        return color;
    }
}
