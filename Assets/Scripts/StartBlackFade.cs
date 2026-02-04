using UnityEngine;
using UnityEngine.UI;

public class StartBlackFade : MonoBehaviour
{
    public Image imageToFade;
    public float duration = 2f;

    private void Start()
    {
        if (imageToFade != null)
        {
            StartCoroutine(FadeBlackOut());
        }
    }

    private System.Collections.IEnumerator FadeBlackOut()
    {
        float elapsedTime = 0f;
        Color startColor = imageToFade.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            imageToFade.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }

        imageToFade.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}
