using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu"); // Replace with your actual game scene name
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
