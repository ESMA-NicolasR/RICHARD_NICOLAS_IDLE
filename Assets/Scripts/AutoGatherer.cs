using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoGatherer : MonoBehaviour
{
    [SerializeField]
    private Image _progressionBar;
    
    private float _progression = 0f;
    [SerializeField]
    private float _harvestSpeed = 0f;
    [SerializeField] private int _harvestPower = 1;

    // Update is called once per frame
    void Update()
    {
        _progression += Time.deltaTime * _harvestSpeed;
        if (_progression >= 1f)
        {
            AutoHarvest();
            _progression -= 1f;
        }
        _progressionBar.fillAmount = _progression;
        _progressionBar.color = Color.Lerp(Color.white, Color.yellow, _progression);
    }

    private void AutoHarvest()
    {
        GameManager.Instance.seedManager.AddSeeds(_harvestPower);
    }

    public void UpgradeAutoHarvestPower()
    {
        _harvestPower++;
    }

    public void UpgradeAutoHarvestRate()
    {
        if (_harvestSpeed < 5f)
        {
            _harvestSpeed += 0.5f;
        }
    }
}