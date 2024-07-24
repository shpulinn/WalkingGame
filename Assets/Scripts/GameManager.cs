using System;
using ButchersGames;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    [SerializeField] private PlayerMove _playerMove;

    [SerializeField] private int levelMoneyGoal = 20;

    public int LevelMoneyGoal => levelMoneyGoal;

    private void Start()
    {
        _playerMove.OnMove += OnMove;
    }

    private void OnMove()
    {
        startCanvas.SetActive(false);
    }

    public void Lose()
    {
        loseCanvas.SetActive(true);
    }

    public void Win()
    {
        winCanvas.SetActive(true);
    }
}