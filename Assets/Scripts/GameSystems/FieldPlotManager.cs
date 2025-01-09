using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPlotManager : MonoBehaviour
{
    // Gameplay
    private List<GameObject> _pooledObjects;
    private int _activatedObjectsNb;
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _amountToPool;
    [SerializeField] private Transform _poolParent;
    [SerializeField] private GameObject _upgradeWithinPool;
    
    void Awake()
    {
        _pooledObjects = new List<GameObject>();
        _activatedObjectsNb = 0;
        GameObject tmp;
        // Create every field plot needed
        for(int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool, _poolParent);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
        // Make sure the buy button is at the end
        _upgradeWithinPool.transform.SetAsLastSibling();
    }

    private void Start()
    {
        StartCoroutine(GrowCoroutine());
    }

    private IEnumerator GrowCoroutine()
    {
        while (true)
        {
            float deltaTime = Time.deltaTime;
            foreach (GameObject go in _pooledObjects)
            {
                if (go.activeInHierarchy)
                {
                    go.GetComponent<FieldPlot>().GrowFood(deltaTime);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private GameObject GetPooledFieldPlot()
    {
        for(int i = 0; i < _amountToPool; i++)
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
        if (_activatedObjectsNb == _amountToPool)
        {
            _upgradeWithinPool.SetActive(false);
        }
        
        return tmp != null;
    }
    
    public GameObject GetIdleFieldPlot()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            if(_pooledObjects[i].activeInHierarchy && _pooledObjects[i].GetComponent<FieldPlot>().IsIdle())
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
    
    public bool AutomateFieldPlot()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            if(!_pooledObjects[i].GetComponent<FieldPlot>().GetIsAutomated())
            {
                _pooledObjects[i].GetComponent<FieldPlot>().Automate();
                return true;
            }
        }
        return false;
    }
}
