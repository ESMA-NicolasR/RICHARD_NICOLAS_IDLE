using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlot : MonoBehaviour
{
    // Display
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image _harvestProgressBar;
    [SerializeField] private Image _harvestBackgroundBar;
    
    // Gameplay
    [SerializeField] private Food _food;
    private bool _isIdle;
    private bool _isRipe;
    private float _growthTime;
    
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("new food : " + newFood.name);
        _foodImage.enabled = true;
        _harvestBackgroundBar.enabled = true;
        _harvestProgressBar.enabled = true;
        _food = newFood;
        _foodImage.sprite = _food.growingSprite;
        _harvestProgressBar.fillAmount = 0f;
        _isRipe = false;
        _isIdle = false;
        _growthTime = 0f;
        StartCoroutine(GrowFood());
    }

    private IEnumerator GrowFood()
    {
        while (!_isRipe)
        {
            yield return new WaitForEndOfFrame();
            _growthTime += Time.deltaTime;
            _isRipe = _growthTime >= _food.baseTimeToGrow;
            _harvestProgressBar.fillAmount = _growthTime / _food.baseTimeToGrow;
        }

        _foodImage.sprite = _food.ripeSprite;
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
        GameManager.Instance.foodManager.AddFood(_food.foodTypeEnum, _food.GetYieldAmount());
        _isRipe = false;
        _isIdle = true;
        _foodImage.enabled = false;
        _harvestBackgroundBar.enabled = false;
        _harvestProgressBar.enabled = false;
    }

    public bool IsIdle()
    {
        return _isIdle;
    }
}
