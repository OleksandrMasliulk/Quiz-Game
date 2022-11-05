using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField, TextArea(2,5)] private string _question;
    public string Question => _question;
}
