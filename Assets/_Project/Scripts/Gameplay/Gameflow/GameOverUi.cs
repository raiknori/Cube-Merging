using UnityEngine;
using Zenject;

public class GameOverUi:MonoBehaviour
{
    [SerializeField] GameObject gameOverText;

    [Inject] IGameOver gameOver;

    private void Awake()
    {
        gameOver.OnGameOver += ShowText;
    }
    void ShowText()
    {
        gameOverText.SetActive(true);
    }
}
