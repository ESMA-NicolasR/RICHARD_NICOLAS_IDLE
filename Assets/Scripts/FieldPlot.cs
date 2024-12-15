using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlot : MonoBehaviour
{
    // Display
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image _harvestProgressBar;
    [SerializeField] private Image _harvestBackgroundBar;
    [SerializeField] private TextMeshProUGUI _floatingText;
    [SerializeField] private Animator _textAnimator;
    
    // Gameplay
    [SerializeField] private Food _food;
    private bool _isIdle;
    private bool _isRipe;
    private float _growTime;
    public bool isAutomated;
    
    // Start is called before the first frame update
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
        _growTime = 0f;
        StartCoroutine(GrowFood());
    }

    private IEnumerator GrowFood()
    {
        float timeToGrow = _food.GetTimeToGrow();
        while (!_isRipe)
        {
            yield return new WaitForEndOfFrame();
            _growTime += Time.deltaTime;
            _harvestProgressBar.fillAmount = _growTime / timeToGrow;
            _isRipe = _growTime >= timeToGrow;
        }

        if (isAutomated)
        {
            Harvest();
        }
        else
        {
            _foodImage.sprite = _food.ripeSprite;
            DisplayFloatingText("Ripe !");
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
    
}
