using UnityEngine;
using TMPro;
using System.Collections;

public class BoxFollow : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 holdOffset = new Vector3(0f, -0.6f, -0.05f);
    public GameObject targetCube;
    public GameObject winCanvas;

    public MonoBehaviour cameraLookScript;
    public TextMeshProUGUI timerText;

    private bool hasWon = false;
    private float timer = 0f;
    private bool timerActive = false;

    void Start()
    {
        
        StartCoroutine(StartTimerAfterDelay(3f));
    }

    void LateUpdate()
    {
        if (playerCamera == null || hasWon) return;

        transform.position = playerCamera.position + playerCamera.TransformDirection(holdOffset);
        transform.rotation = playerCamera.rotation;

        
        if (timerActive && !hasWon)
        {
            timer += Time.deltaTime;
            if (timerText != null)
                timerText.text = timer.ToString("F1"); //f1 for extra decimal place??
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasWon) return;

        if (collision.gameObject == targetCube)
        {
            Win();
        }
    }

    void Win()
    {
        hasWon = true;

        if (winCanvas != null)
            winCanvas.SetActive(true);

        
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        timerActive = true;
    }
}
