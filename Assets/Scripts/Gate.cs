using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private GateVisual _gateVisual;

    private MoneyManager _moneyManager;

    private void OnValidate()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
        _gateVisual.UpdateData(_value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_moneyManager)
        {
            if (_value > 0)
            {
                _moneyManager.Add(_value);
            }
            else
            {
                _moneyManager.SpendMoney(_value * -1);
            }
            Destroy(gameObject);
        }
    }
}