using System;
using UnityEngine;

public class WorldHungerManager : MonoBehaviour
{
    // Delegates
    public static Action<long> OnPeopleFedNbChanged;

    // Gameplay
    [SerializeField] private long _peopleFedNb;
    [SerializeField] private long _totalPeopleToFeed;

    private void OnEnable()
    {
        SaveSystem.OnSave += OnSave;
        SaveSystem.OnLoad += OnLoad;
    }

    private void OnDisable()
    {
        SaveSystem.OnSave -= OnSave;
        SaveSystem.OnLoad -= OnLoad;
    }


    void Start()
    {
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }

    public void FeedPeople(long nbPeople)
    {
        _peopleFedNb += (int)(nbPeople * GameManager.Instance.upgradeManager.GetScalingValue(UpgradeScalingEnum.MultWorldHungerReward));
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }

    public long GetPeopleFedNb()
    {
        return _peopleFedNb;
    }
    
    public long GetTotalPeopleToFeed()
    {
        return _totalPeopleToFeed;
    }
    
    public string GetProgressAsTextWithIcons()
    {
        return $"<sprite name=hunger>{_peopleFedNb:N0} / {_totalPeopleToFeed:N0}";
    }

    private void OnSave(SaveData save)
    {
        save.worldHunger = _peopleFedNb;
    }

    private void OnLoad(SaveData save)
    {
        _peopleFedNb = save.worldHunger;
        OnPeopleFedNbChanged?.Invoke(_peopleFedNb);
    }
}
