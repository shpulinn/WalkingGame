using System;
using UnityEngine;
using System.Collections.Generic;

public class ProgressManager : MonoBehaviour
{
    [System.Serializable]
    public class UpgradeLevel
    {
        public int requiredMoney;
        public GameObject characterModel;
        public RuntimeAnimatorController animatorController;
        public ParticleSystem upgradeEffect;
    }

    public List<UpgradeLevel> upgradeLevels;
    public float maxProgressValue = 100f;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private UIProgressBar uiProgressBar;

    private int currentUpgradeIndex = 0;
    private float currentProgress = 0f;
    private MoneyManager moneyManager;
    private GameObject currentCharacterModel;

    #region Singletone
    private static ProgressManager _default;
    public static ProgressManager Default { get => _default; }
    public ProgressManager() => _default = this;
    #endregion

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        //characterAnimator = GetComponentInChildren<Animator>();

        // Убедимся, что все скины, кроме начального, выключены
        for (int i = 1; i < upgradeLevels.Count; i++)
        {
            if (upgradeLevels[i].characterModel != null)
            {
                upgradeLevels[i].characterModel.SetActive(false);
            }
        }

        SetCharacterLevel(currentUpgradeIndex);
    }

    public void AddProgress(float value)
    {
        currentProgress += value;
        UpdateProgress();
    }

    public void RemoveProgress(float value)
    {
        currentProgress -= value;
        if (currentProgress < 0) currentProgress = 0;
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        Debug.Log(currentProgress);
        if (currentProgress >= maxProgressValue && currentUpgradeIndex < upgradeLevels.Count - 1)
        {
            UpgradeCharacter();
        }
        else if (currentProgress <= 0 && currentUpgradeIndex > 0)
        {
            DowngradeCharacter();
        }

        currentProgress = Mathf.Clamp(currentProgress, 0, maxProgressValue);
        
        if (uiProgressBar != null)
        {
            uiProgressBar.UpdateProgress(currentProgress / maxProgressValue, currentUpgradeIndex + 1);
        }
    }

    private void UpgradeCharacter()
    {
        if (currentUpgradeIndex < upgradeLevels.Count - 1)
        {
            currentUpgradeIndex++;
            SetCharacterLevel(currentUpgradeIndex);
            currentProgress = 0f;
        }
    }
    
    private void DowngradeCharacter()
    {
        currentUpgradeIndex--;
        SetCharacterLevel(currentUpgradeIndex);
        currentProgress = maxProgressValue;
    }

    private void SetCharacterLevel(int index)
    {
        UpgradeLevel level = upgradeLevels[index];

        // Выключаем все скины
        foreach (var upgradeLevel in upgradeLevels)
        {
            if (upgradeLevel.characterModel != null)
            {
                upgradeLevel.characterModel.SetActive(false);
            }
        }

        // Включаем нужный скин
        if (level.characterModel != null)
        {
            level.characterModel.SetActive(true);
        }

        // Обновляем анимацию
        if (level.animatorController != null && characterAnimator != null)
        {
            characterAnimator.runtimeAnimatorController = level.animatorController;
        }

        // Проигрываем эффект улучшения
        if (level.upgradeEffect != null)
        {
            Instantiate(level.upgradeEffect, characterAnimator.transform.position + Vector3.up, Quaternion.identity);
        }

        // Обновляем требуемое количество денег в LevelManager
        //LevelManager levelManager = FindObjectOfType<LevelManager>();
        //if (levelManager != null)
        //{
        //    levelManager.UpdateRequiredMoney(level.requiredMoney);
        //}
    }

    public void CollectMoney()
    {
        moneyManager.AddOne();
        AddProgress(1);
    }

    public void CollectBadItem(int moneyLoss)
    {
        moneyManager.SpendMoney(moneyLoss);
        RemoveProgress(moneyLoss);
    }
}