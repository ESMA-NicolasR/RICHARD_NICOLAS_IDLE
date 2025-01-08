using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    [SerializeField] private GameObject lockedGameObject;
    [SerializeField] private Image lockImage;

    public void Lock()
    {
        lockImage.enabled = true;
        lockedGameObject.SetActive(false);
    }

    public void Unlock()
    {
        lockImage.enabled = false;
        lockedGameObject.SetActive(true);
        // Force update for specific mono behaviours
        UpgradeBuyer upgradeBuyer = lockedGameObject.GetComponentInChildren<UpgradeBuyer>();
        if(upgradeBuyer != null)
            upgradeBuyer.UpdateDisplay();
        FoodPlanter foodPlanter = lockedGameObject.GetComponentInChildren<FoodPlanter>();
        if (foodPlanter != null)
            foodPlanter.UpdateDisplay();
    }
}
