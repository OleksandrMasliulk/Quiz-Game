using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _congratulationsText;
    private ScoreKeeper _scoreKeeper;

    private void Awake() 
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>(true);
    }
    
    public void OnEnable() 
    {
        _congratulationsText.text += $"\nYou scored {_scoreKeeper.CalculateScore()}%";
    }

    public void Restart() 
    {
        SceneManager.LoadScene(0);
    }
}
