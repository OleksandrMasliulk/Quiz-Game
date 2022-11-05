using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionTextField;
    [SerializeField] private GameObject[] _answerButtons;

    [SerializeField] QuestionSO _question;

    void Start()
    {
        _questionTextField.text = _question.Question;

        for (int i = 0; i < _answerButtons.Length; i++) 
        {
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _question.GetAnswer(i);
        }
    }
}
