using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame() // ✅ Must be public & have no parameters
    {
        Debug.Log("Start Button Clicked!");
        SceneManager.LoadScene("Main Menu"); // Replace with your next scene name
    }

    public void ExitGame()
    {
        Debug.Log("Exit Button Clicked!");
        Application.Quit();
    }
}
