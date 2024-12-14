using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldHungerDisplay : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI flavorText;
    private void OnEnable()
    {
        WorldHungerManager.OnPeopleFedNbChanged += OnPeopleFedNbChanged;
    }

    private void OnPeopleFedNbChanged(long peopleFedNb)
    {
        progressBar.fillAmount = GetFilledFraction(peopleFedNb);
        progressText.text = GameManager.Instance.worldHungerManager.GetProgressAsTextWithIcons();
    }
    
    private float GetFilledFraction(long amount)
    {
        return Mathf.Log(amount, GameManager.Instance.worldHungerManager.GetTotalPeopleToFeed());
    }
}
