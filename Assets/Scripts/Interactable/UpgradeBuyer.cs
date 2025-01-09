using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuyer : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private TextMeshProUGUI _rankText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Button _button;
    // Gameplay
    [SerializeField] private UpgradeTemplate _upgradeTemplate;
    private ResourceDict _resourceCost;
    private int _currentRank;
    private int _maxRank;
    private bool _isMaxedOut;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }

    private void Awake()
    {
        _currentRank = 0;
        _isMaxedOut = false;
        _maxRank = _upgradeTemplate.GetMaxRank();
        _upgradeText.text = _upgradeTemplate.description;
        UpdateUpgradeRank();
    }


    public void BuyUpgrade()
    {
        if (GameManager.Instance.resourceManager.SpendResource(_resourceCost))
        {
            GameManager.Instance.upgradeManager.UnlockUpgrade(_upgradeTemplate.upgrade);
            _currentRank++;
            UpdateUpgradeRank();
            UpdateDisplay();
        }
    }

    private void UpdateUpgradeRank()
    {
        if (_maxRank == 0 || _currentRank < _maxRank)
        {   // We can still upgrade after
            _resourceCost = _upgradeTemplate.GetCostForRank(_currentRank);
            _costText.text = _resourceCost.GetStringWithSprites();
        }
        else
        {   // We reached max rank of upgrade
            _button.enabled = false;
            _button.image.color = Color.grey;
            _costText.enabled = false;
            _isMaxedOut = true;
        }
        // Update rank
        if (_maxRank > 0)
        {
            _rankText.text = $"Rank\n{_currentRank}/{_maxRank}";
        }
        else
        {
            _rankText.text = $"Rank\n{_currentRank}";
        }
    }
    
    private void OnResourceAmountChanged(ResourceTypeEnum resourceType)
    {
        // Only update if relevant resource has changed
        if(_resourceCost.CheckKey(resourceType) && !_isMaxedOut)
            UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        _button.interactable = GameManager.Instance.resourceManager.CheckCanSpendResource(_resourceCost);
    }
}
