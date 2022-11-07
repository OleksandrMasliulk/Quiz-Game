using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Quiz _quiz;
    private WinScreen _winScreen;

    private void Awake() 
    {
        _quiz = FindObjectOfType<Quiz>(true);
        _winScreen = FindObjectOfType<WinScreen>(true);
    }

    private void Start() 
    {
        StartGame();
    }

    private void Update() 
    {
        if (_quiz.IsComplete)
        {
            ShowWinScreen();
        }
    }

    private void StartGame() 
    {
        _quiz.gameObject.SetActive(true);
        _winScreen.gameObject.SetActive(false);
    }

    private void ShowWinScreen() 
    {
        _winScreen.gameObject.SetActive(true);
        _winScreen.ShowScore();
        _quiz.gameObject.SetActive(false);
    }
}
