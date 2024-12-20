using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradeReferences : MonoBehaviour
{
    public GameObject newCerealBuyer;
    public List<Locker> cerealPlanters;
    public List<GameObject> fruitPlanters;
    public List<GameObject> vegetablePlanters;
    public int cerealUnlockedNb;
    public int fruitUnlockedNb;
    public int vegetableUnlockedNb;
    public GameObject cerealCounter;
    public GameObject fruitCounter;
    public GameObject vegetableCounter;
    public GameObject fieldPlotBuyer;
    public List<GameObject> firstShopUnlockBuyers;
    public GameObject autoGatherSpeedBuyer;
    public GameObject autoGatherDisplay;
    public List<Locker> cerealUpgrades;
    public List<GameObject> fruitUpgrades;
    public List<GameObject> vegetableUpgrades;

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
            fruitPlanters[i].SetActive(i<fruitUnlockedNb);
        }
        for(int i=0; i<vegetablePlanters.Count; i++)
        {
            vegetablePlanters[i].SetActive(i<vegetableUnlockedNb);
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
            foreach (GameObject go in fruitUpgrades)
            {
                go.SetActive(false);
            }
        }
        if (vegetableUnlockedNb == 0)
        {
            vegetableCounter.SetActive(false);
            foreach (GameObject go in vegetableUpgrades)
            {
                go.SetActive(false);
            }
        }
        // Hide field plot buyer
        fieldPlotBuyer.SetActive(GameManager.Instance.fieldPlotManager.GetIdleFieldPlot()!=null);
        // Hide auto gather
        autoGatherDisplay.SetActive(false);
        autoGatherSpeedBuyer.SetActive(false);
        // Hide first shop upgrades
        firstShopUnlockBuyers.ForEach(value => value.SetActive(false));
    }
}
