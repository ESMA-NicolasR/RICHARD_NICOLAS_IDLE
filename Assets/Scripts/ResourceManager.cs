using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Gameplay
    private ResourceDict _resourceStorage;
    
    // Delegates
    public static event Action<ResourceTypeEnum, long> OnResourceAmountChanged;
    

    // Start is called before the first frame update
    void Awake()
    {
        _resourceStorage = new ResourceDict();
        foreach (ResourceTypeEnum resourceType in Enum.GetValues(typeof(ResourceTypeEnum)))
        {
            _resourceStorage.Add(resourceType, 0);
        }
    }
    
    public long GetResourceAmount(ResourceTypeEnum resourceTypeEnum)
    {
        return _resourceStorage[resourceTypeEnum];
    }

    public void AddResource(ResourceTypeEnum resourceTypeEnum, long nbAdd)
    {
        _resourceStorage[resourceTypeEnum] += nbAdd;
        OnResourceAmountChanged?.Invoke(resourceTypeEnum, _resourceStorage[resourceTypeEnum]);
    }
    
    public void AddResource(ResourceDict resources)
    {
        resources.ForEach(AddResource);
    }
    

    public bool CheckCanSpendResource(ResourceTypeEnum resourceTypeEnum, long nbSpend)
    {
        return _resourceStorage[resourceTypeEnum] >= nbSpend;
    }

    public bool CheckCanSpendResource(ResourceDict resourceCost)
    {
        bool canSpend = true;
        
        // Check if every cost is affordable
        resourceCost.ForEach((key, value) => canSpend &= CheckCanSpendResource(key, value));

        return canSpend;
    }
    
    public bool SpendResource(ResourceTypeEnum resourceType, long nbSpend)
    {
        if (!CheckCanSpendResource(resourceType, nbSpend))
        {
            return false;
        }
        _resourceStorage[resourceType] -= nbSpend;
        OnResourceAmountChanged?.Invoke(resourceType, _resourceStorage[resourceType]);
        return true;
    }

    public bool SpendResource(ResourceDict resourceCost)
    {
        if (!CheckCanSpendResource(resourceCost))
        {
            return false;
        }
        resourceCost.ForEach((key, value) => SpendResource(key, value));
        
        return true;
    }
}
