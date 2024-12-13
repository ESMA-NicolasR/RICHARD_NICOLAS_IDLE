using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHungerManager : MonoBehaviour
{
    private long _peopleFedNb;

    public static Action<long> OnPeopleFedNbChanged;

    [SerializeField] private long _totalPeopleToFeed;
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

    public void FeedPeople(long nbPeople)
    {
        _peopleFedNb += nbPeople;
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }

    public long GetPeopleFedNb()
    {
        return _peopleFedNb;
    }
    
    public string GetProgressAsTextWithIcons()
    {
        // TODO change sprite
        return $"<sprite name=seed>{_peopleFedNb:N0} / {_totalPeopleToFeed:N0}";
    }
}
