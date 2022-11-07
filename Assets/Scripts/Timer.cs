using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToAnswerQuestion;
    [SerializeField] private float _timeToShowCorrectAnswer;

    public bool isAnsweringQuestion = true;

    private float _timerValue;

    private void Start() 
    {
        SetupTimer();
    }

    private void Update() 
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (_timerValue <= 0) 
        {
            isAnsweringQuestion = !isAnsweringQuestion;
            SetupTimer();
        }

        Debug.Log(_timerValue);
    }

    private void SetupTimer() 
    {
        if (isAnsweringQuestion) 
        {
            _timerValue = _timeToAnswerQuestion;
        }
        else
        {
            _timerValue = _timeToShowCorrectAnswer;
        }
    }
}
