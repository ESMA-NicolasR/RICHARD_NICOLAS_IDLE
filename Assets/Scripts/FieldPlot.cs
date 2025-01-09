using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlot : MonoBehaviour
{
    // Display
    [SerializeField] private Image _foodImage;
    [SerializeField] private GameObject _rotatingImage;
    [SerializeField] private Image _harvestProgressBar;
    [SerializeField] private Image _harvestBackgroundBar;
    [SerializeField] private TextMeshProUGUI _floatingText;
    [SerializeField] private Animator _textAnimator;
    
    // Gameplay
    [SerializeField] private Food _food;
    private bool _isIdle;
    private bool _isRipe;
    private float _currentGrowTime;
    private float _targetGrowTime;
    private bool _isAutomated;
    
    void Start()
    {
        _floatingText.text = "";
        _foodImage.enabled = false;
        _harvestProgressBar.enabled = false;
        _harvestBackgroundBar.enabled = false;
        _isIdle = true;
        _isRipe = false;
        if(_food != null)
            SetFood(_food);
    }

    public void SetFood(Food newFood)
    {
        DisplayFloatingText("Growing...");
        _foodImage.enabled = true;
        _harvestBackgroundBar.enabled = true;
        _harvestProgressBar.enabled = true;
        _food = newFood;
        _foodImage.sprite = _food.growingSprite;
        _harvestProgressBar.fillAmount = 0f;
        _isRipe = false;
        _isIdle = false;
        _currentGrowTime = 0f;
        _targetGrowTime = _food.GetTimeToGrow();
    }

    public void GrowFood(float deltaTime)
    {
        // Nothing to grow
        if (_isIdle || _isRipe)
        {
            return;
        }
        // Is growing
        _currentGrowTime += deltaTime;
        _harvestProgressBar.fillAmount = _currentGrowTime / _targetGrowTime;
        _isRipe = _currentGrowTime >= _targetGrowTime;
        // Has just finished growing
        if (_isRipe)
        {
            if (_isAutomated)
            {
                Harvest();
            }
            else
            {
                _foodImage.sprite = _food.ripeSprite;
                DisplayFloatingText("Ripe !");
            }
        }
    }

    public void OnClick()
    {
        if (_isRipe)
        {
            Harvest();
        }
        else
        {
            Debug.Log("Not Ripe");
        }
    }

    private void Harvest()
    {
        int yield = _food.GetYieldAmount();
        GameManager.Instance.resourceManager.AddResource(_food.resourceTypeEnum, yield);
        DisplayFloatingText($"+{_food.GetYieldSprite()}{yield}");
        _isRipe = false;
        _isIdle = true;
        _foodImage.enabled = false;
        _harvestBackgroundBar.enabled = false;
        _harvestProgressBar.enabled = false;
    }

    private void DisplayFloatingText(string text)
    {
        _floatingText.text = text;
        _textAnimator.SetTrigger("PopUp");
    }

    public bool IsIdle()
    {
        return _isIdle;
    }

    public void Automate()
    {
        _isAutomated = true;
        _rotatingImage.SetActive(true);
    }

    public bool GetIsAutomated()
    {
        return _isAutomated;
    }
    
}
