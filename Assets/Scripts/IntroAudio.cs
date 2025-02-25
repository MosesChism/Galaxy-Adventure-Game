using UnityEngine;

public class IntroAudio : MonoBehaviour
{
    public AudioSource introSound; // Assign the voice sound byte
    public AudioSource backgroundMusic; // Assign the background music

    void Start()
    {
        if (introSound != null)
        {
            introSound.Play(); // Play the intro sound
            Invoke("PlayBackgroundMusic", introSound.clip.length); // Wait for the intro to finish before starting music
        }
        else
        {
            PlayBackgroundMusic(); // Start music immediately if no intro sound
        }
    }

    void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }
}
