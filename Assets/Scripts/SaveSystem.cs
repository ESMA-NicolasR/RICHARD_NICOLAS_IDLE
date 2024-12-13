using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public void MakeSave()
    {
        PlayerPrefs.SetFloat("WorldHunger", (float)GameManager.Instance.worldHungerManager.GetPeopleFedNb());
    }

    public void LoadSave()
    {
        GameManager.Instance.worldHungerManager.FeedPeople((long)PlayerPrefs.GetFloat("WorldHunger"));
    }
}
