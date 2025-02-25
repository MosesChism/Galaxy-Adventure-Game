using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play(); // Start the music if it's not playing
        }
    }
}
