using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private ResourceTypeEnum _resourceType;
    [SerializeField] private TextMeshProUGUI _resourceText;
    [SerializeField] private Animator _textAnimator;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }

    private void Start()
    {
        // Fail-safe display of the starting amount of resources
        UpdateDisplay();
    }

    private void OnResourceAmountChanged(ResourceTypeEnum resourceTypeEnumChanged)
    {
        if (resourceTypeEnumChanged == _resourceType)
        {
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        _resourceText.text = GameManager.Instance.resourceManager.GetResourceAmount(_resourceType).ToString();
        _textAnimator.SetTrigger("Wiggle");
    }
}
