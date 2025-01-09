using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoGatherer : MonoBehaviour
{
    // Display
    [SerializeField] private Image _progressionBar;
    [SerializeField] private TextMeshProUGUI _autoGatherText;
    // Gameplay
    private float _progression;
    [SerializeField] private float _gatherRatePerSecond;
    public bool isActive;

    // Tweaking
    private const float MAX_RATE = 5f;
    private const float UPGRADE_RATE = .5f;
    
    private void Start()
    {
        _progression = 0f;
        UpdateDisplay();
    }
    
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
        if (_gatherRatePerSecond < MAX_RATE)
        {
            _gatherRatePerSecond += UPGRADE_RATE;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        _autoGatherText.text = $"Auto gathering\n({(_gatherRatePerSecond):F2}/s)";
    }
}