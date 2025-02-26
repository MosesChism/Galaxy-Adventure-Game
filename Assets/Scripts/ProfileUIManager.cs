using UnityEngine;

public class ProfileUIManager : MonoBehaviour
{
    public GameObject profileSelectionPanel;
    public GameObject profileCreationPanel;

    void Start()
    {
        ShowProfileSelection(); // Start with profile selection visible
    }

    public void ShowProfileSelection()
    {
        profileSelectionPanel.SetActive(true);
        profileCreationPanel.SetActive(false);
    }

    public void ShowProfileCreation()
    {
        profileSelectionPanel.SetActive(false);
        profileCreationPanel.SetActive(true);
    }
}
