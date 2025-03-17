using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RetryButton : MonoBehaviour
{
    public Button retryButton;
    public MathQuestionGenerator questionGenerator;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText; // Optional: If you have a feedback message

    void Start()
    {
        retryButton.onClick.AddListener(RetryQuestion);
        retryButton.gameObject.SetActive(false); // Hide retry button at start
    }

    public void ShowRetryButton()
    {
        retryButton.gameObject.SetActive(true);
    }

    void RetryQuestion()
    {
        // Clear input field
        answerInput.text = "";

        // Hide retry button again
        retryButton.gameObject.SetActive(false);

        // Reset feedback text (optional)
        if (feedbackText != null)
            feedbackText.text = "";

        // Generate a new math question
        questionGenerator.GenerateMathQuestion();
    }
}
