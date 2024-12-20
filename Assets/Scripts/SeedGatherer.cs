using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedGatherer : MonoBehaviour
{
    [SerializeField] private long _gatherPower = 1;
    [SerializeField] private TextMeshProUGUI _gatherText;

    private void Start()
    {
        UpdateDisplay();
    }

    public void GatherSeed()
    {
        GameManager.Instance.resourceManager.AddResource(ResourceTypeEnum.Seed, _gatherPower);
    }

    public void IncreaseGatherPower(long nb)
    {
        _gatherPower += nb;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _gatherText.text = $"Gather <sprite name=seed>({_gatherPower})";
    }
}
