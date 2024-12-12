using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class WorldHungerScaling
{
    public double lowerBound;
    public double upperBound;
    public float ratio;

    public float GetFilledFraction(double amount)
    {
        if (amount < lowerBound)
        {
            return 0f;
        }
        
        return Mathf.Lerp(0f, ratio, (float)(amount/upperBound));
    }
}

public class WorldHungerDisplay : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI flavorText;
    [SerializeField] private List<WorldHungerScaling> worldHungerScalings;
    private void OnEnable()
    {
        WorldHungerManager.OnPeopleFedNbChanged += OnPeopleFedNbChanged;
    }

    private void OnPeopleFedNbChanged(int peopleFedNb)
    {
        progressBar.fillAmount = worldHungerScalings.Sum(scaling => scaling.GetFilledFraction(peopleFedNb));
    }
}
