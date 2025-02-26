using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public InputField playerNameInput;
    public Text welcomeText;
    public GameObject profilePanel;

    void Start()
    {
        LoadProfile();
    }

    public void SaveProfile()
    {
        string playerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            welcomeText.text = "Welcome, " + playerName + "!";
            profilePanel.SetActive(false);  // Hide profile setup after saving
        }
    }

    void LoadProfile()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string savedName = PlayerPrefs.GetString("PlayerName");
            welcomeText.text = "Welcome back, " + savedName + "!";
            profilePanel.SetActive(false); // Hide profile setup if already saved
        }
    }
}
