using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    void Start()
    {
        StartCoroutine(PlayFromFourSeconds());
    }

    System.Collections.IEnumerator PlayFromFourSeconds()
    {
        // Wait one frame to ensure AudioSource is fully initialized
        yield return null;

        backgroundMusic.time = 4f;
        backgroundMusic.Play();
        backgroundMusic.loop = true;
    }
}
