using UnityEngine;

public class ChangeColorPlayerTrigger : MonoBehaviour
{
    [SerializeField] private Color hitColor = Color.red;
    private Color originalColor;

    private Renderer objectRenderer;
    private AudioSource audioSource;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        originalColor = objectRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        objectRenderer.material.color = hitColor;

        // Play sound only if not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        objectRenderer.material.color = originalColor;
    }
}
