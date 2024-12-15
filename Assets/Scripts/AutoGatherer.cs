using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoGatherer : MonoBehaviour
{
    [SerializeField]
    private Image _progressionBar;
    [SerializeField] private TextMeshProUGUI _autoGatherText;
    
    private float _progression;
    [SerializeField]
    private float _gatherRatePerSecond;

    public bool isActive;

    private void Start()
    {
        _progression = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;
        
        _progression += Time.deltaTime * _gatherRatePerSecond;
        if (_progression >= 1f)
        {
            AutoGather();
            _progression -= 1f;
        }
        _progressionBar.fillAmount = _progression;
        _progressionBar.color = Color.Lerp(Color.white, Color.yellow, _progression);
    }

    public void BeginAutoGathering()
    {
        isActive = true;
    }

    private void AutoGather()
    {
        GameManager.Instance.seedGatherer.GatherSeed();
    }
    

    public void UpgradeAutoHarvestRate()
    {
        if (_gatherRatePerSecond < 5f)
        {
            _gatherRatePerSecond += 0.5f;
            _autoGatherText.text = $"Auto gathering\n({(_gatherRatePerSecond):F2}/s)";
        }
    }
}