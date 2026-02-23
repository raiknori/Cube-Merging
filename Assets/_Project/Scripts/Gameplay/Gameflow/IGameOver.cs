using System;

public interface IGameOver
{
    event Action OnGameOver;

    void GameOver();
}
