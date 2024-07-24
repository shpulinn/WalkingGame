using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _topImage;
    [SerializeField] private Image _glassImage;

    [SerializeField] private Color _colorPositive;
    [SerializeField] private Color _colorNegative;

    private const string PlusPrefix = "+";

    public void UpdateData(int value)
    {
        _text.text = value.ToString();
        if (value >= 0)
        {
            _topImage.color = _colorPositive;
            _text.text = PlusPrefix + _text.text;
        }
        else
        {
            _topImage.color = _colorNegative;
        }
        _glassImage.color = new Color(_topImage.color.r, _topImage.color.g, _topImage.color.b, .5f);
    }
}
