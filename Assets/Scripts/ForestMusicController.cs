using UnityEngine;

public class ForestMusicController : MonoBehaviour
{
    public AudioSource forestMusic;

    void Start()
    {
        forestMusic.time = 4f;      // Skip first 4 seconds
        forestMusic.Play();         // Play from 4s
        forestMusic.loop = true;    // Loop the track if desired
    }
}
