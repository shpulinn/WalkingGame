using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    public Image fillImage;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI percentText;
    
    public void UpdateProgress(float progress, int currentLevel)
    {
        fillImage.fillAmount = progress;
        
        if (percentText != null)
        {
            percentText.text = $"{progress * 100:F0}%";
        }
        
        if (levelText != null)
        {
            levelText.text = $"Level: {currentLevel}";
        }
    }
}