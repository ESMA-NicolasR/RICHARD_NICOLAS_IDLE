using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeBuyable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Button _button;
    [SerializeField] private ResourceDict _resourceCost;
    [SerializeField] private UnityEvent _onUpgrade;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void Start()
    {
        _costText.text = _resourceCost.GetStringWithSprites();
    }

    public void BuyUpgrade()
    {
        if (GameManager.Instance.resourceManager.SpendResource(_resourceCost))
        {
            _onUpgrade.Invoke();
        }
    }

    private void OnResourceAmountChanged(ResourceTypeEnum resourceType, int amount)
    {
        if(_resourceCost.CheckKey(resourceType))
            UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        _button.interactable = GameManager.Instance.resourceManager.CheckCanSpendResource(_resourceCost);
    }
}
