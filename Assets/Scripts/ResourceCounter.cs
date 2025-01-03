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
        OnResourceAmountChanged(_resourceType, GameManager.Instance.resourceManager.GetResourceAmount(_resourceType));
    }

    private void OnResourceAmountChanged(ResourceTypeEnum resourceTypeEnumChanged, long amount)
    {
        if (resourceTypeEnumChanged == _resourceType)
        {
            _resourceText.text = amount.ToString();
            _textAnimator.SetTrigger("Wiggle");
        }
    }
}
