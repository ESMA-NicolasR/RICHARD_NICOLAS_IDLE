using UnityEngine;
using TMPro;

public class SeedCounter : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        SeedManager.OnNbSeedsChanged += OnNbSeedsChanged;
    }

    private void OnDisable()
    {
        SeedManager.OnNbSeedsChanged -= OnNbSeedsChanged;
    }

    private void OnNbSeedsChanged(int nbSeeds)
    {
        _counterText.text = $"Seeds : {nbSeeds}";
    }
}
