using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] private List<QuestionSO> _questions;
    QuestionSO _currentQuestion;
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

    [Header("Scoring")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    private ScoreKeeper _scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] private Slider _progressBar;

    [Header("Win Screen")]
    [SerializeField] private GameObject _winScreen;
    public bool _isComplete = false;

    private bool _hasAnsweredEarly = false;

    private void Awake() 
    {
        _timer = FindObjectOfType<Timer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        SetupProgressBar();
    }

    private void Update() 
    {
        _timerImage.fillAmount = _timer.FillFraction;
        if (_timer.loadNextQuestion) 
        {
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer.loadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer.IsAnsweringQuestion)
        {
            ShowAnswer(-1);
            SetButtonsState(false);
        }
    }

    private void GetNextQuestion() 
    {
        if (_isComplete)
        {
            GameComplete();
        }
        else
        {
            GetRandomQuestion();
            SetButtonsState(true);
            SetDefaultButtonSprites();
            SetupQuestion();
            _scoreKeeper.IncrementQuestionsSeen();
        }
    }

    private void GetRandomQuestion() 
    {
        int rand = Random.Range(0, _questions.Count);
        _currentQuestion = _questions[rand];

        if (_questions.Contains(_currentQuestion))
        {
            _questions.Remove(_currentQuestion);
        }
    }

    public void OnAnswerSelected(int index) 
    {
        _hasAnsweredEarly = true;
        ShowAnswer(index);
        SetButtonsState(false);
        _timer.CancelTimer();
    }

    private void ShowAnswer(int index) 
    {
        Image buttonImage;
        if (index == _currentQuestion.CorrectAnswerIndex) 
        {
            _questionTextField.text = "Correct!";
            buttonImage = _answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = _correctButtonSprite;
            _scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            int correctAnswerIndex = _currentQuestion.CorrectAnswerIndex;
            string correctAnswerText = _currentQuestion.GetAnswer(correctAnswerIndex);
            _questionTextField.text = $"The correct answer was:\n{correctAnswerText}";
            if (_hasAnsweredEarly) 
            {
                buttonImage = _answerButtons[index].GetComponent<Image>();
                buttonImage.sprite = _wrongButtonSprite;
            }
            Image correctButtonImage = _answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = _correctButtonSprite;
        }

        _scoreText.text = $"Score: {_scoreKeeper.CalculateScore()}%";
        UpdateProgressBar();
    }

    private void SetupQuestion() 
    {
        _questionTextField.text = _currentQuestion.Question;

        for (int i = 0; i < _answerButtons.Length; i++) 
        {
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _currentQuestion.GetAnswer(i);
        }
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

    private void SetupProgressBar() 
    {
        _progressBar.maxValue = _questions.Count;
        _progressBar.value = 0;
    }

    private void UpdateProgressBar() 
    {
        _progressBar.value = _scoreKeeper.QuestionsSeen;
        if (_progressBar.value == _progressBar.maxValue) 
        {
            _isComplete = true;
        }
    }

    private void GameComplete() 
    {
        _winScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
