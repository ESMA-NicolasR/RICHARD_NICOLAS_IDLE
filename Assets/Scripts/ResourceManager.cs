using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Gameplay
    private ResourceDict _resourceStorage;
    
    // Delegates
    public static event Action<ResourceTypeEnum> OnResourceAmountChanged;

    private void OnEnable()
    {
        SaveSystem.OnSave += OnSave;
        SaveSystem.OnLoad += OnLoad;
    }

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
        OnResourceAmountChanged?.Invoke(resourceTypeEnum);
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
        OnResourceAmountChanged?.Invoke(resourceType);
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

    private void OnSave(SaveData save)
    {
        save.resources = _resourceStorage;
    }
    
    private void OnLoad(SaveData save)
    {
        _resourceStorage = save.resources;
        foreach (ResourceTypeEnum resourceType in _resourceStorage.GetKeys())
        {
            OnResourceAmountChanged?.Invoke(resourceType);
        }
    }
}
