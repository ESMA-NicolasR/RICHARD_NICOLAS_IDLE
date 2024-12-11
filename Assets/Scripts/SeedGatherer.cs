using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedGatherer : MonoBehaviour
{
    [SerializeField] private int _gatherPower = 1;
    [SerializeField] private TextMeshProUGUI _gatherText;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GatherSeed()
    {
        GameManager.Instance.resourceManager.AddResource(ResourceTypeEnum.Seed, _gatherPower);
    }

    public void IncreaseGatherPower()
    {
        _gatherPower++;
        _gatherText.text = $"Gather seeds ({_gatherPower})";
    }
}
