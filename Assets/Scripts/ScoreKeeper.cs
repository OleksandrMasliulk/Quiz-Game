using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _correctAnswers;
    private int _questionsSeen;

    public int CorrectAnswers => _correctAnswers;
    public int QuestionsSeen => _questionsSeen;

    public void IncrementCorrectAnswers() => _correctAnswers++;
    public void IncrementQuestionsSeen() => _questionsSeen++;

    public int CalculateScore() 
    {
        return Mathf.RoundToInt(_correctAnswers / (float)_questionsSeen * 100);
    }
}
