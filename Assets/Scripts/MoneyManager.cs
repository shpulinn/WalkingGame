using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int numberOfMoney;
    [SerializeField] private TextMeshProUGUI moneyLabel;
    [SerializeField] private GameManager _gameManager;

    public int NumberOfMoney => numberOfMoney;

    private void Start()
    {
        UpdateCoinsAmountLabel();
    }

    public void Add(int amount)
    {
        numberOfMoney += amount;
        UpdateCoinsAmountLabel();
    }

    public void AddOne()
    {
        numberOfMoney++;
        UpdateCoinsAmountLabel();
    }

    public void SaveMoneyProgress()
    {
    }

    public void SpendMoney(int amount)
    {
        if (amount > numberOfMoney)
        {
            _gameManager.Lose();
            numberOfMoney = 0;
            UpdateCoinsAmountLabel();
            return;
        }
        numberOfMoney -= amount;
        SaveMoneyProgress();
        UpdateCoinsAmountLabel();
    }

    private void UpdateCoinsAmountLabel()
    {
        if (moneyLabel == null)
        {
            return;
        }
        moneyLabel.text = $"{numberOfMoney.ToString()}$";
    }
}