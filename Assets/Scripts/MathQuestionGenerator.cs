using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathQuestionGenerator : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public Button submitButton;
    public Button retryButton;
    public Button continueButton;
    public Button mainMenuButton;
    public Text feedbackText;
    public Text scoreText;
    public GameObject stageCompletePanel;

    private int currentGrade;
    private int currentStage;
    private int num1, num2, correctAnswer;
    private string currentOperation;
    private int questionCount = 0;
    private int totalQuestions = 10;
    private int score = 0;

    void Start()
    {
        currentGrade = GameManager.Instance.GetDifficulty();
        currentStage = GameManager.Instance.CurrentStage; // ✅ Pull current stage from GameManager
        GenerateMathQuestion();
        UpdateScore();
    }

    public void GenerateMathQuestion()
    {
        if (questionCount >= totalQuestions)
        {
            StageComplete();
            return;
        }

        questionCount++;

        // Stage 1 = Addition/Basic, Stage 2 = Multiplication Focus
        if (currentStage == 1)
        {
            switch (currentGrade)
            {
                case 1:
                    num1 = Random.Range(1, 20);
                    num2 = Random.Range(1, 20);
                    currentOperation = "+";
                    correctAnswer = num1 + num2;
                    break;
                case 2:
                    num1 = Random.Range(10, 50);
                    num2 = Random.Range(10, 50);
                    currentOperation = (Random.value > 0.5f) ? "+" : "-";
                    correctAnswer = (currentOperation == "+") ? (num1 + num2) : (num1 - num2);
                    break;
                case 3:
                    num1 = Random.Range(20, 100);
                    num2 = Random.Range(1, 5);
                    currentOperation = new string[] { "+", "-", "×" }[Random.Range(0, 3)];
                    correctAnswer = (currentOperation == "+") ? (num1 + num2) :
                                    (currentOperation == "-") ? (num1 - num2) :
                                    (num1 * num2);
                    break;
                case 4:
                case 5:
                    num1 = Random.Range(100, 500);
                    num2 = Random.Range(10, 100);
                    currentOperation = "+";
                    correctAnswer = num1 + num2;
                    break;
            }
        }
        else if (currentStage == 2)
        {
            switch (currentGrade)
            {
                case 1:
                    num1 = Random.Range(1, 5);
                    num2 = Random.Range(1, 5);
                    break;
                case 2:
                    num1 = Random.Range(1, 10);
                    num2 = Random.Range(1, 10);
                    break;
                case 3:
                    num1 = Random.Range(10, 50);
                    num2 = Random.Range(1, 10);
                    break;
                case 4:
                    num1 = Random.Range(50, 100);
                    num2 = Random.Range(10, 20);
                    break;
                case 5:
                    num1 = Random.Range(100, 999);
                    num2 = Random.Range(10, 99);
                    break;
            }

            currentOperation = "×";
            correctAnswer = num1 * num2;
        }

        questionText.text = $"{num1} {currentOperation} {num2} = ?";
    }

    public void CheckAnswer()
    {
        int playerAnswer;
        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "✅ Correct!";
                score += 10;
                UpdateScore();
                GenerateMathQuestion();
            }
            else
            {
                feedbackText.text = "❌ Wrong! Try Again.";
            }
        }
        else
        {
            feedbackText.text = "⚠ Enter a valid number.";
        }

        answerInput.text = "";
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void StageComplete()
    {
        Debug.Log("Stage Complete!");
        stageCompletePanel.SetActive(true);
    }

    public void ContinueToNextStage()
    {
        GameManager.Instance.AdvanceStage(); // ✅ Go to next stage
        SceneManager.LoadScene("GStage2");
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.ResetStage(); // ✅ Reset stage on return
        SceneManager.LoadScene("MainMenu");
    }
}
