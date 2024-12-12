using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHungerManager : MonoBehaviour
{
    private double _peopleFedNb;

    public static Action<double> OnPeopleFedNbChanged;

    [SerializeField] private int _totalPeopleToFeed;
    // Start is called before the first frame update
    void Start()
    {
        _peopleFedNb = 0;
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeedPeople(double nbPeople)
    {
        _peopleFedNb += nbPeople;
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }

    public double GetPeopleFedNb()
    {
        return _peopleFedNb;
    }
}
