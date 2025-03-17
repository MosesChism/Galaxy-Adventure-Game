using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private static BackgroundManager instance;

    private void Awake()
    {
        // Ensure there is only one instance of the background across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }
}
