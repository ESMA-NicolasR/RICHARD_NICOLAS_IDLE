using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeBuyable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private ResourceDict _resourceCost;
    [SerializeField] private UnityEvent _onUpgrade;

    public void BuyUpgrade()
    {
        if (GameManager.Instance.resourceManager.SpendResource(_resourceCost))
        {
            _onUpgrade.Invoke();
        }
        else
        {
            Debug.Log("Not enough resource");
        }
    }
}
