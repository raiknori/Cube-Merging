using TMPro;
using UnityEngine;
using Zenject;

public class ScoreController : MonoBehaviour
{
    [SerializeField] int ScoreWin;
    [SerializeField] TextMeshProUGUI scoreText;
    [Inject] private IMergeService mergeService;
    [Inject] private IGameOver gameOver;
    public int score;
    int Score
    {
        get { return score; }

        set 
        {
            score = value;
            UpdateScore();

            if(score >= ScoreWin)
            {
                gameOver.GameOver();
            }
        }
    }

    private void Awake()
    {
        mergeService.MergeCompleted += CalculateScore;
    }

    void CalculateScore(int newValue)
    {
        if (newValue == 2)
            return;
        
        Score += newValue/4;

    }
    void UpdateScore()
    {
        scoreText.SetText($"{Score}");
    }
}
