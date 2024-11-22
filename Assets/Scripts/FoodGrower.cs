using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _foodGrower : MonoBehaviour
{
    // Display
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image _harvestProgressBar;
    
    // Gameplay
    [SerializeField] private Food _food;
    private bool _isRipe;
    private float _growthTime;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_food != null)
            SetFood(_food);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFood(Food newFood)
    {
        StartCoroutine(GrowFood(newFood));
    }

    private IEnumerator GrowFood(Food newFood)
    {
        _foodImage.sprite = _food.growingSprite;
        _harvestProgressBar.fillAmount = 0f;
        _isRipe = false;

        while (!_isRipe)
        {
            yield return new WaitForEndOfFrame();
            _growthTime += Time.deltaTime;
            _isRipe = _growthTime >= _food.baseTimeToGrow;
            _harvestProgressBar.fillAmount = _growthTime / _food.baseTimeToGrow;
        }

        _foodImage.sprite = _food.ripeSprite;
    }
}
