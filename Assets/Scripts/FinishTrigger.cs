using System;
using ButchersGames;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private Animator _gatesAnimator;

    private int _animTriggerWinID;

    private void Start()
    {
        _animTriggerWinID = Animator.StringToHash("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerBehaviour = other.GetComponent<PlayerBehaviour>();
        if (_gameManager.LevelMoneyGoal > _moneyManager.NumberOfMoney)
        {
            Lose(playerBehaviour);
        }
        else
        {
            Win(playerBehaviour);
        }
    }

    private void Lose(PlayerBehaviour playerBehaviour)
    {
        playerBehaviour.StartLosingBehaviour();
        _gameManager.Lose();
    }

    private void Win(PlayerBehaviour playerBehaviour)
    {
        playerBehaviour.StartWinningBehaviour();
        _gatesAnimator.SetTrigger(_animTriggerWinID);
        _gameManager.Win();
    }
}