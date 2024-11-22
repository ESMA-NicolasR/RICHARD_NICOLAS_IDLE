using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    
    private SeedManager _seedManager;
    // Start is called before the first frame update
    void Start()
    {
        _seedManager = SeedManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        int nbSeeds = _seedManager.GetSeedNb();
        _counterText.text = $"Seeds : {nbSeeds}";
    }
}
