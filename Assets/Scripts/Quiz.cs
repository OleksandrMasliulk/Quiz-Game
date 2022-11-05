using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionTextField;

    [SerializeField] QuestionSO _question;

    void Start()
    {
        _questionTextField.text = _question.Question;
    }
}
