using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPlotManager : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private Transform poolParent;
    
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, poolParent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    
    private GameObject GetPooledFieldPlot()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
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
        }
        return tmp != null;
    }
    
    public GameObject GetIdleFieldPlot()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(pooledObjects[i].activeInHierarchy && pooledObjects[i].GetComponent<FieldPlot>().IsIdle())
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
