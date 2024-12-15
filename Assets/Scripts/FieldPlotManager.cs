using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPlotManager : MonoBehaviour
{
    private List<GameObject> _pooledObjects;
    private int _activatedObjectsNb;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private Transform poolParent;
    [SerializeField] private GameObject _upgradeWithinPool;
    
    void Awake()
    {
        _pooledObjects = new List<GameObject>();
        _activatedObjectsNb = 0;
        GameObject tmp;
        // Create every field plot needed
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, poolParent);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
        // Make sure the buy button is at the end
        _upgradeWithinPool.transform.SetAsLastSibling();
    }
    
    private GameObject GetPooledFieldPlot()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }

    public bool ActivateFieldPlot()
    {
        GameObject tmp = GetPooledFieldPlot();
        if (tmp != null)
        {
            tmp.SetActive(true);
            _activatedObjectsNb++;
        }
        // Check if we bought every field plot
        if (_activatedObjectsNb == amountToPool)
        {
            _upgradeWithinPool.SetActive(false);
        }
        
        return tmp != null;
    }
    
    public GameObject GetIdleFieldPlot()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(_pooledObjects[i].activeInHierarchy && _pooledObjects[i].GetComponent<FieldPlot>().IsIdle())
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
