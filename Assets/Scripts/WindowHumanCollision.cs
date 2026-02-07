using UnityEngine;

public class WindowHumanCollision : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("Player"))
        {
            objectRenderer.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("Player"))
        {
            objectRenderer.enabled = true;
        }
    }
}


