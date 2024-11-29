using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedGatherer : MonoBehaviour
{
    [SerializeField] private int _gatherPower = 1;
    [SerializeField] private TextMeshProUGUI _gatherText;
    private SeedManager _seedManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _seedManager = SeedManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GatherSeed()
    {
        _seedManager.AddSeeds(_gatherPower);
    }

    public void IncreaseGatherPower()
    {
        _gatherPower++;
        _gatherText.text = $"Gather seeds ({_gatherPower})";
    }
}
