using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeImage10Sec : MonoBehaviour
{
    public RawImage targetRawImage;

    public VideoPlayer firstVideo;
    public VideoPlayer secondVideo;
    public VideoPlayer thirdVideo;

    public RenderTexture firstTexture;
    public RenderTexture secondTexture;
    public RenderTexture thirdTexture;

    public float switchDelay = 10f;

    void Start()
    {
        PlayVideo(firstVideo, firstTexture);
        Invoke(nameof(SwitchToSecond), switchDelay);
    }

    void PlayVideo(VideoPlayer player, RenderTexture texture)
    {
        // Stop all videos first
        firstVideo.Stop();
        secondVideo.Stop();
        thirdVideo.Stop();

        // Set texture
        targetRawImage.texture = texture;

        // Play selected video
        player.Play();
    }

    void SwitchToSecond()
    {
        PlayVideo(secondVideo, secondTexture);
        Invoke(nameof(SwitchToThird), switchDelay);
    }

    void SwitchToThird()
    {
        PlayVideo(thirdVideo, thirdTexture);
        Invoke(nameof(SwitchToFirst), switchDelay); // 👈 loop back
    }

    void SwitchToFirst()
    {
        PlayVideo(firstVideo, firstTexture);
        Invoke(nameof(SwitchToSecond), switchDelay); // 👈 continue loop
    }
}
