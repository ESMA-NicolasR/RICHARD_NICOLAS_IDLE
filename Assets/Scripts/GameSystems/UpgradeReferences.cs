using System.Collections.Generic;
using UnityEngine;

public class UpgradeReferences : MonoBehaviour
{
    public List<Locker> cerealPlanters;
    public List<Locker> fruitPlanters;
    public List<Locker> vegetablePlanters;
    public int cerealUnlockedNb;
    public int fruitUnlockedNb;
    public int vegetableUnlockedNb;
    public GameObject cerealCounter;
    public GameObject fruitCounter;
    public GameObject vegetableCounter;
    public GameObject fieldPlotBuyer;
    public List<Locker> firstShopUnlockBuyers;
    public GameObject autoGatherSpeedBuyer;
    public GameObject autoGatherDisplay;
    public List<Locker> cerealUpgrades;
    public List<Locker> fruitUpgrades;
    public List<Locker> vegetableUpgrades;

    private void Start()
    {
        // Hide the food not yet unlocked 
        for(int i=0; i<cerealPlanters.Count; i++)
        {
            if (i < cerealUnlockedNb) cerealPlanters[i].Unlock();
            else cerealPlanters[i].Lock();
        }
        for(int i=0; i<fruitPlanters.Count; i++)
        {
            if (i < fruitUnlockedNb) fruitPlanters[i].Unlock();
            else fruitPlanters[i].Lock();
        }
        for(int i=0; i<vegetablePlanters.Count; i++)
        {
            if (i < vegetableUnlockedNb) vegetablePlanters[i].Unlock();
            else vegetablePlanters[i].Lock();
        }
        // Hide elements for food not unlocked
        if (cerealUnlockedNb == 0)
        {
            cerealCounter.SetActive(false);
            foreach (Locker locker in cerealUpgrades)
            {
                locker.Lock();
            }
        }
        if (fruitUnlockedNb == 0)
        {
            fruitCounter.SetActive(false);
            foreach (Locker locker in fruitUpgrades)
            {
                locker.Lock();
            }
        }
        if (vegetableUnlockedNb == 0)
        {
            vegetableCounter.SetActive(false);
            foreach (Locker locker in vegetableUpgrades)
            {
                locker.Lock();
            }
        }
        // Hide field plot buyer
        fieldPlotBuyer.SetActive(GameManager.Instance.fieldPlotManager.GetIdleFieldPlot()!=null);
        // Hide auto gather
        autoGatherDisplay.SetActive(false);
        autoGatherSpeedBuyer.SetActive(false);
        // Hide first shop upgrades
        firstShopUnlockBuyers.ForEach(value => value.Lock());
    }
}
