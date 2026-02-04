using TMPro;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public GameObject beam;
    public GameObject floor;

    public GameObject loseCanvas;

    public TextMeshProUGUI counterText;

    public float survivalTime = 0f;

    private bool gameEnded = false;
    private bool counterStarted = false; 
    private float timer = 0f;
    private int counter = 0;

    void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;

        // Start the counter ONCE when time reaches survivalTime
        if (!counterStarted && timer >= survivalTime)
        {
            counterStarted = true;
            StartCoroutine(CounterCoroutine());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameEnded) return;

        if (collision.gameObject == floor)
        {
            Lose();
        }
    }

    void Lose()
    {
        gameEnded = true;
        loseCanvas.SetActive(true);
    }

    System.Collections.IEnumerator CounterCoroutine()
    {
        while (!gameEnded)
        {
            counter++;

            if (counterText != null)
                counterText.text = counter.ToString();

            yield return new WaitForSeconds(2f);
        }
    }
}
