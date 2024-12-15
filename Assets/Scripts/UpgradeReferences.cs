using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeReferences : MonoBehaviour
{
    public List<GameObject> cerealUnlockers;
    public List<GameObject> fruitUnlockers;
    public List<GameObject> vegetableUnlockers;
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

    private void Start()
    {
        // Hide the food not yet unlocked 
        for(int i=0; i<cerealUnlockers.Count; i++)
        {
            cerealUnlockers[i].SetActive(i<cerealUnlockedNb);
        }
        for(int i=0; i<fruitUnlockers.Count; i++)
        {
            fruitUnlockers[i].SetActive(i<fruitUnlockedNb);
        }
        for(int i=0; i<vegetableUnlockers.Count; i++)
        {
            vegetableUnlockers[i].SetActive(i<vegetableUnlockedNb);
        }
        // Hide counters for food not unlocked
        if (cerealUnlockedNb == 0)
        {
            cerealCounter.SetActive(false);
        }
        if (fruitUnlockedNb == 0)
        {
            fruitCounter.SetActive(false);
        }
        if (vegetableUnlockedNb == 0)
        {
            vegetableCounter.SetActive(false);
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
