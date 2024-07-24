using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMove _playerMove;

    private int _animBoolWinID;
    private int _animBoolLoseID;

    private void OnValidate()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        _animBoolWinID = Animator.StringToHash("Win");
        _animBoolLoseID = Animator.StringToHash("Lose");
    }

    public void StartLosingBehaviour()
    {
        _animator.SetBool(_animBoolLoseID, true);
        _playerMove.enabled = false;
    }

    public void StartWinningBehaviour()
    {
        _animator.SetBool(_animBoolWinID, true);
        _playerMove.enabled = false;
    }
}