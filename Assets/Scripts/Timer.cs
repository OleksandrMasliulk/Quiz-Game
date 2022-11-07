using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToAnswerQuestion;
    [SerializeField] private float _timeToShowCorrectAnswer;

    public bool loadNextQuestion;
    private bool _isAnsweringQuestion = true;

    private float _timerValue;

    private void Start() 
    {
        SetupTimer();
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
            float fillFraction = CalculateFillFraction();
            Debug.Log($"{_timerValue} = {(int)(fillFraction * 100)}%");
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

    private float CalculateFillFraction() 
    {
        if (_isAnsweringQuestion)
        {
            return _timerValue / _timeToAnswerQuestion;
        }
        else
        {
            return _timerValue / _timeToShowCorrectAnswer;
        }
    }
}
