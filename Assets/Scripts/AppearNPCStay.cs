using UnityEngine;
using System.Collections;

public class AppearNPCStay : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;
    [SerializeField] private float appearTime = 5f;
    [SerializeField] private float disappearTime = 2f;

    private Coroutine appearCoroutine;
    private Coroutine disappearCoroutine;

    void Start()
    {
        objectToToggle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("NPC")) return;

        // Cancel disappearance if NPC comes back
        if (disappearCoroutine != null)
        {
            StopCoroutine(disappearCoroutine);
            disappearCoroutine = null;
        }

        // Start appear timer if object is not active
        if (!objectToToggle.activeSelf && appearCoroutine == null)
        {
            appearCoroutine = StartCoroutine(AppearAfterTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("NPC")) return;

        // Cancel appear timer if NPC leaves early
        if (appearCoroutine != null)
        {
            StopCoroutine(appearCoroutine);
            appearCoroutine = null;
        }

        // Start disappear timer if object is active
        if (objectToToggle.activeSelf && disappearCoroutine == null)
        {
            disappearCoroutine = StartCoroutine(DisappearAfterTime());
        }
    }

    private IEnumerator AppearAfterTime()
    {
        yield return new WaitForSeconds(appearTime);
        objectToToggle.SetActive(true);
        appearCoroutine = null;
    }

    private IEnumerator DisappearAfterTime()
    {
        yield return new WaitForSeconds(disappearTime);
        objectToToggle.SetActive(false);
        disappearCoroutine = null;
    }
}
