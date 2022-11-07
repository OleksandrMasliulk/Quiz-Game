using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToAnswerQuestion;
    [SerializeField] private float _timeToShowCorrectAnswer;

    public bool loadNextQuestion;
    private bool _isAnsweringQuestion;
    public bool IsAnsweringQuestion => _isAnsweringQuestion;

    private float _timerValue;
    public float FillFraction { get; private set; }

    private void Start() 
    {
        //SetupTimer();
    }

    private void Update() 
    {
        UpdateTimer();
    }

    public void CancelTimer() 
    {
        _timerValue = 0f;
    }

    private void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (_timerValue <= 0) 
        {
            _isAnsweringQuestion = !_isAnsweringQuestion;
            SetupTimer();
        }
        else
        {
            CalculateFillFraction();
        }
    }

    private void SetupTimer() 
    {
        if (_isAnsweringQuestion) 
        {
            loadNextQuestion = true;
            _timerValue = _timeToAnswerQuestion;
        }
        else
        {
            _timerValue = _timeToShowCorrectAnswer;
        }
    }

    private void CalculateFillFraction() 
    {
        if (_isAnsweringQuestion)
        {
            FillFraction = _timerValue / _timeToAnswerQuestion;
        }
        else
        {
            FillFraction =  _timerValue / _timeToShowCorrectAnswer;
        }
    }
}
