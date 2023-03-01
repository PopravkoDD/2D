using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private AnimationCurve _lightFlickering;
    [SerializeField] private Light _light;
    [SerializeField] private float _timeBetweenFlickerings;
    [SerializeField] private bool _isLightActive;
    void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        var animationTime = 0f;
        while (_isLightActive)
        {
            while (animationTime <= _lightFlickering.keys[^1].time)
            {
                _light.intensity = _lightFlickering.Evaluate(animationTime);
                animationTime += Time.deltaTime;
                yield return null;
            }

            animationTime = 0f;
            yield return new WaitForSeconds(_timeBetweenFlickerings);
        }
    }
}
