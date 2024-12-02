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
    
    // Gameplay
    [SerializeField] private Food _food;
    private bool _isIdle;
    private bool _isRipe;
    private float _growthTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _isIdle = true;
        _isRipe = false;
        if(_food != null)
            SetFood(_food);
    }

    public void SetFood(Food newFood)
    {
        Debug.Log("new food : " + newFood.name);
        _food = newFood;
        StartCoroutine(GrowFood());
    }

    private IEnumerator GrowFood()
    {
        _foodImage.sprite = _food.growingSprite;
        _harvestProgressBar.fillAmount = 0f;
        _isRipe = false;
        _isIdle = false;
        _growthTime = 0f;

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
        FoodManager.Instance.AddFood(_food.foodTypeEnum, _food.GetYieldAmount());
        _foodImage.sprite = null;
        _harvestProgressBar.fillAmount = 0f;
        _isRipe = false;
        _isIdle = true;
    }

    public bool IsIdle()
    {
        return _isIdle;
    }
}
