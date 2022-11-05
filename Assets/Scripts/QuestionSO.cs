using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField, TextArea(2,5)] private string _question;
    [SerializeField] private string[] _answers = new string[4];
    [SerializeField] private int _correctAnswerIndex; 

    public string Question => _question;
    public int CorrectAnswerIndex => _correctAnswerIndex;

    public string GetAnswer(int index) => _answers[index];

    private void OnValidate() 
    {
        if (_answers.Length > 0 && _correctAnswerIndex > _answers.Length - 1)
        {
            _correctAnswerIndex = _answers.Length - 1;
        }
        else if (_answers.Length == 0 || _correctAnswerIndex < 0)
        {
            _correctAnswerIndex = 0;
        }
    }
}
