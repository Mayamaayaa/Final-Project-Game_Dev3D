using UnityEngine;

public class PortalSoundTrigger : MonoBehaviour
{
    public AudioSource portalSound;

    void Start()
    {
        if (portalSound == null)
            portalSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !portalSound.isPlaying)
        {
            portalSound.Play();
        }
    }
}
