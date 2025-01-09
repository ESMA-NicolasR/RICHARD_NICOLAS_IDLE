using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    // Display
    [SerializeField] private GameObject _lockedGameObject;
    [SerializeField] private Image _lockImage;

    public void Lock()
    {
        _lockImage.enabled = true;
        _lockedGameObject.SetActive(false);
    }

    public void Unlock()
    {
        _lockImage.enabled = false;
        _lockedGameObject.SetActive(true);
        // Force update for specific mono behaviours
        UpgradeBuyer upgradeBuyer = _lockedGameObject.GetComponentInChildren<UpgradeBuyer>();
        if(upgradeBuyer != null)
            upgradeBuyer.UpdateDisplay();
        FoodPlanter foodPlanter = _lockedGameObject.GetComponentInChildren<FoodPlanter>();
        if (foodPlanter != null)
            foodPlanter.UpdateDisplay();
    }
}
