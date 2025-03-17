using UnityEngine;

public class PersistentBackground : MonoBehaviour
{
    private static PersistentBackground instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across all scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates when returning to the title screen
        }
    }
}
