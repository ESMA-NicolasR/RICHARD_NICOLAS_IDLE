using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeBuyer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private TextMeshProUGUI _rankText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Button _button;
    [SerializeField] private UpgradeTemplate _upgradeTemplate;
    private ResourceDict _resourceCost;
    private int _currentRank;
    private int _maxRank;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }

    private void Awake()
    {
        _currentRank = 0;
        _maxRank = _upgradeTemplate.GetMaxRank();
        _upgradeText.text = _upgradeTemplate.description;
        UpdateUpgradeRank();
    }


    public void BuyUpgrade()
    {
        if (GameManager.Instance.resourceManager.SpendResource(_resourceCost))
        {
            GameManager.Instance.upgradeManager.UnlockUpgrade(_upgradeTemplate.upgrade);
            _currentRank++;
            UpdateUpgradeRank();
        }
    }

    private void UpdateUpgradeRank()
    {
        // Update cost
        if (_maxRank == 0 || _currentRank < _maxRank)
        {
            _resourceCost = _upgradeTemplate.GetCostForRank(_currentRank);
            _costText.text = _resourceCost.GetStringWithSprites();
        }
        else
        {
            _button.interactable = false;
            _costText.enabled = false;
        }
        // Update rank
        if (_maxRank > 0)
        {
            _rankText.text = $"Rank\n{_currentRank}/{_maxRank}";
        }
        else
        {
            _rankText.text = $"Rank\n{_currentRank}";
        }
    }
    
    private void OnResourceAmountChanged(ResourceTypeEnum resourceType)
    {
        // Only update if relevant resource has changed
        if(_resourceCost.CheckKey(resourceType))
            UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        _button.image.color = GameManager.Instance.resourceManager.CheckCanSpendResource(_resourceCost) ? Color.white: Color.red;
    }
}
