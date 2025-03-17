using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Dropdown genderDropdown;
    public InputField nameInput;
    public InputField ageInput;

    [Header("Base Avatar")]
    public Image baseAvatarRenderer;

    [Header("Avatar Parts")]
    public Image hairRenderer;
    public Image shirtRenderer;
    public Image pantsRenderer;
    public Image shoesRenderer;

    [Header("Character Assets")]
    public Sprite[] maleHairstyles;
    public Sprite[] femaleHairstyles;
    public Sprite[] nonBinaryHairstyles;

    public Sprite[] maleShirts;
    public Sprite[] femaleShirts;
    public Sprite[] nonBinaryShirts;

    public Sprite[] malePants;
    public Sprite[] femalePants;
    public Sprite[] nonBinaryPants;

    public Sprite[] maleShoes;
    public Sprite[] femaleShoes;
    public Sprite[] nonBinaryShoes;

    private int hairIndex = 0;
    private int shirtIndex = 0;
    private int pantsIndex = 0;
    private int shoesIndex = 0;

    private Sprite[] currentHairstyles;
    private Sprite[] currentShirts;
    private Sprite[] currentPants;
    private Sprite[] currentShoes;

    void Start()
    {
        genderDropdown.onValueChanged.AddListener(delegate { UpdateCustomizationOptions(); });
        UpdateCustomizationOptions();
    }

    void UpdateCustomizationOptions()
    {
        string selectedGender = genderDropdown.options[genderDropdown.value].text;

        switch (selectedGender)
        {
            case "Men":
                currentHairstyles = maleHairstyles;
                currentShirts = maleShirts;
                currentPants = malePants;
                currentShoes = maleShoes;
                break;

            case "Women":
                currentHairstyles = femaleHairstyles;
                currentShirts = femaleShirts;
                currentPants = femalePants;
                currentShoes = femaleShoes;
                break;

            case "NonBinary":
                currentHairstyles = nonBinaryHairstyles;
                currentShirts = nonBinaryShirts;
                currentPants = nonBinaryPants;
                currentShoes = nonBinaryShoes;
                break;
        }

        hairIndex = 0;
        shirtIndex = 0;
        pantsIndex = 0;
        shoesIndex = 0;

        UpdateAvatar();
    }

    public void NextHairStyle()
    {
        hairIndex = (hairIndex + 1) % currentHairstyles.Length;
        UpdateAvatar();
    }

    public void PrevHairStyle()
    {
        hairIndex = (hairIndex - 1 + currentHairstyles.Length) % currentHairstyles.Length;
        UpdateAvatar();
    }

    public void NextShirtStyle()
    {
        shirtIndex = (shirtIndex + 1) % currentShirts.Length;
        UpdateAvatar();
    }

    public void PrevShirtStyle()
    {
        shirtIndex = (shirtIndex - 1 + currentShirts.Length) % currentShirts.Length;
        UpdateAvatar();
    }

    public void NextPantsStyle()
    {
        pantsIndex = (pantsIndex + 1) % currentPants.Length;
        UpdateAvatar();
    }

    public void PrevPantsStyle()
    {
        pantsIndex = (pantsIndex - 1 + currentPants.Length) % currentPants.Length;
        UpdateAvatar();
    }

    public void NextShoesStyle()
    {
        shoesIndex = (shoesIndex + 1) % currentShoes.Length;
        UpdateAvatar();
    }

    public void PrevShoesStyle()
    {
        shoesIndex = (shoesIndex - 1 + currentShoes.Length) % currentShoes.Length;
        UpdateAvatar();
    }

    void UpdateAvatar()
    {
        if (currentHairstyles.Length > 0)
            hairRenderer.sprite = currentHairstyles[hairIndex];

        if (currentShirts.Length > 0)
            shirtRenderer.sprite = currentShirts[shirtIndex];

        if (currentPants.Length > 0)
            pantsRenderer.sprite = currentPants[pantsIndex];

        if (currentShoes.Length > 0)
            shoesRenderer.sprite = currentShoes[shoesIndex];

        AlignAvatarParts();
    }

   void AlignAvatarParts()
{
    // Ensure all elements are children of Base Avatar
    hairRenderer.transform.SetParent(baseAvatarRenderer.transform, false);
    shirtRenderer.transform.SetParent(baseAvatarRenderer.transform, false);
    pantsRenderer.transform.SetParent(baseAvatarRenderer.transform, false);
    shoesRenderer.transform.SetParent(baseAvatarRenderer.transform, false);

    // Force all positions to stay in place
    hairRenderer.rectTransform.localPosition = new Vector3(0, 40, 0);
    shirtRenderer.rectTransform.localPosition = new Vector3(0, 0, 0);
    pantsRenderer.rectTransform.localPosition = new Vector3(0, -30, 0);
    shoesRenderer.rectTransform.localPosition = new Vector3(0, -50, 0);

    // Ensure scaling is uniform
    hairRenderer.rectTransform.localScale = Vector3.one;
    shirtRenderer.rectTransform.localScale = Vector3.one;
    pantsRenderer.rectTransform.localScale = Vector3.one;
    shoesRenderer.rectTransform.localScale = Vector3.one;
}

}
