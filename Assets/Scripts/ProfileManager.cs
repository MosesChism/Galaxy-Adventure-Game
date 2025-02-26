using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public InputField nameInput;
    public InputField ageInput;
    public Dropdown genderDropdown;
    public Image characterPreview;
    
    private int selectedHair = 0;
    private int selectedShirt = 0;
    private int selectedPants = 0;
    private int selectedShoes = 0;

    public Sprite[] hairStyles;
    public Sprite[] shirts;
    public Sprite[] pants;
    public Sprite[] shoes;

    void Start()
    {
        LoadProfile(); // Load existing profile if any
    }

    public void SaveProfile()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.SetInt("PlayerAge", int.Parse(ageInput.text));
        PlayerPrefs.SetInt("PlayerGender", genderDropdown.value);
        PlayerPrefs.SetInt("HairStyle", selectedHair);
        PlayerPrefs.SetInt("Shirt", selectedShirt);
        PlayerPrefs.SetInt("Pants", selectedPants);
        PlayerPrefs.SetInt("Shoes", selectedShoes);
        PlayerPrefs.Save();
    }

    void LoadProfile()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            nameInput.text = PlayerPrefs.GetString("PlayerName");
            ageInput.text = PlayerPrefs.GetInt("PlayerAge").ToString();
            genderDropdown.value = PlayerPrefs.GetInt("PlayerGender");
            selectedHair = PlayerPrefs.GetInt("HairStyle");
            selectedShirt = PlayerPrefs.GetInt("Shirt");
            selectedPants = PlayerPrefs.GetInt("Pants");
            selectedShoes = PlayerPrefs.GetInt("Shoes");
            UpdateCharacterPreview();
        }
    }

    public void ChangeHair(int direction)
    {
        selectedHair = (selectedHair + direction + hairStyles.Length) % hairStyles.Length;
        UpdateCharacterPreview();
    }

    public void ChangeShirt(int direction)
    {
        selectedShirt = (selectedShirt + direction + shirts.Length) % shirts.Length;
        UpdateCharacterPreview();
    }

    public void ChangePants(int direction)
    {
        selectedPants = (selectedPants + direction + pants.Length) % pants.Length;
        UpdateCharacterPreview();
    }

    public void ChangeShoes(int direction)
    {
        selectedShoes = (selectedShoes + direction + shoes.Length) % shoes.Length;
        UpdateCharacterPreview();
    }

    void UpdateCharacterPreview()
    {
        characterPreview.sprite = hairStyles[selectedHair]; // Update hair preview
        // Repeat for shirts, pants, shoes if using a 2D system
    }
}
