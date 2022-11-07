using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] QuestionSO _question;
    [SerializeField] private TextMeshProUGUI _questionTextField;

    [Header("Answers")]
    [SerializeField] private GameObject[] _answerButtons;

    [Header("Button colors")]
    [SerializeField] private Sprite _defaultButtonSprite;
    [SerializeField] private Sprite _correctButtonSprite;
    [SerializeField] private Sprite _wrongButtonSprite;

    [Header("Timer")]
    [SerializeField] private Image _timerImage;
    private Timer _timer;

    private void Awake() 
    {
        _timer = FindObjectOfType<Timer>();
    }

    void Start()
    {
        GetNextQuestion();
        //SetupQuestion();
    }

    private void Update() 
    {
        _timerImage.fillAmount = _timer.FillFraction;
        if (_timer.loadNextQuestion) 
        {
            GetNextQuestion();
            _timer.loadNextQuestion = false;
        }
    }

    private void SetupQuestion() 
    {
        _questionTextField.text = _question.Question;

        for (int i = 0; i < _answerButtons.Length; i++) 
        {
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _question.GetAnswer(i);
        }
    }

    private void GetNextQuestion() 
    {
        SetButtonsState(true);
        SetDefaultButtonSprites();
        SetupQuestion();
    }

    public void OnAnswerSelected(int index) 
    {
        Image buttonImage = _answerButtons[index].GetComponent<Image>();
        if (index == _question.CorrectAnswerIndex) 
        {
            _questionTextField.text = "Correct!";
            buttonImage.sprite = _correctButtonSprite;
        }
        else
        {
            int correctAnswerIndex = _question.CorrectAnswerIndex;
            string correctAnswerText = _question.GetAnswer(correctAnswerIndex);
            _questionTextField.text = $"The correct answer was:\n{correctAnswerText}";
            buttonImage.sprite = _wrongButtonSprite;
            Image correctButtonImage = _answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = _correctButtonSprite;
        }
        SetButtonsState(false);
        _timer.CancelTimer();
    }

    private void SetButtonsState(bool state) 
    {
        foreach(GameObject go in _answerButtons) 
        {
            Button button = go.GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetDefaultButtonSprites() 
    {
        foreach(GameObject go in _answerButtons) 
        {
            Image image = go.GetComponent<Image>();
            image.sprite = _defaultButtonSprite;
        }
    }
}
