using UnityEngine;

public class VisualController : MonoBehaviour
{
    [Header("Input")]
    public DistanceInput distanceInput;

    [Header("Visual Target")]
    public Light targetLight;

    [Header("Mapping")]
    public float minIntensity = 0.2f;
    public float maxIntensity = 3.0f;

    void Update()
    {
        if (distanceInput == null || targetLight == null)
            return;

        float v = distanceInput.value; // 0–1
        targetLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, v);
    }
}