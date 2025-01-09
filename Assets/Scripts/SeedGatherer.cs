using TMPro;
using UnityEngine;

public class SeedGatherer : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI _gatherText;
    // Gameplay
    [SerializeField] private long _gatherPower = 1;

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
