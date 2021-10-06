using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float _timeWork = 1;
    [SerializeField] private float _intensityMultiply = 1;
    [SerializeField] private AnimationCurve _lightIntensityCurve;

    [SerializeField] private float _radius = 100;
    [SerializeField] private float _hightLightning = 50;
    [SerializeField] private float _angleOffset = 45;

    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Light _light;

    public UnityEvent CreateLightning;

    private Quaternion startLightRotation;

    private void Start()
    {
        startLightRotation = _light.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CalculateDirection();
    }

    [ContextMenu("Cast")]
    private void CalculateDirection()
    {
        _light.transform.rotation = startLightRotation;

        float random = Random.Range(-_angleOffset, _angleOffset);
        Quaternion randomRotation = Quaternion.Euler(0, random, 0);

        _light.transform.rotation *= randomRotation;
        _particle.transform.position = transform.position + (-1 * _light.transform.forward * _radius);

        _particle.Play();
        StartCoroutine(FadeLight());
    }

    private IEnumerator FadeLight()
    {
        _light.enabled = true;
        for (float t = 0; t < 1; t += Time.deltaTime / _timeWork)
        {
            _light.intensity = _lightIntensityCurve.Evaluate(t) * _intensityMultiply;
            yield return null;
        }
        _light.enabled = false;
    }
}
