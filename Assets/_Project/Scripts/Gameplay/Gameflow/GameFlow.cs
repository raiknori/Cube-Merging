using System;
using UnityEngine;


public class GameFlow : MonoBehaviour, IGameOver
{
    public event Action OnGameOver;

    [SerializeField] GameObject controllers;
    [SerializeField] GameObject systems;

    public void GameOver()
    {
        controllers.SetActive(false);
        systems.SetActive(false);

        OnGameOver?.Invoke();
    }
}