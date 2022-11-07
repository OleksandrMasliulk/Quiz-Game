using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionTextField;
    [SerializeField] private GameObject[] _answerButtons;
    [SerializeField] private Sprite _correctAnswerSprite;
    [SerializeField] private Sprite _wrongAnswerSprite;

    [SerializeField] QuestionSO _question;

    void Start()
    {
        _questionTextField.text = _question.Question;

        for (int i = 0; i < _answerButtons.Length; i++) 
        {
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index) 
    {
        Image buttonImage = _answerButtons[index].GetComponent<Image>();
        if (index == _question.CorrectAnswerIndex) 
        {
            _questionTextField.text = "Correct!";
            buttonImage.sprite = _correctAnswerSprite;
        }
        else
        {
            int correctAnswerIndex = _question.CorrectAnswerIndex;
            string correctAnswerText = _question.GetAnswer(correctAnswerIndex);
            _questionTextField.text = $"The correct answer was:\n{correctAnswerText}";
            buttonImage.sprite = _wrongAnswerSprite;
            Image correctButtonImage = _answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = _correctAnswerSprite;
        }
    }
}
