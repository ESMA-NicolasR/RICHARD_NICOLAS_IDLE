using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public long worldHunger;
}

public class SaveSystem : MonoBehaviour
{
    public static Action<SaveData> OnSave;
    public static Action<SaveData> OnLoad;
    private const string SAVE_NAME = "SaveData.json";
    private string _saveFilePath;

    private void Start()
    {
        _saveFilePath = $"{Application.persistentDataPath}/{SAVE_NAME}";
    }

    public void Save()
    {
        SaveData save  = new SaveData();
        // save will store data written by various managers
        OnSave?.Invoke(save);
        string jsonData = JsonUtility.ToJson(save);
        File.WriteAllText(_saveFilePath, jsonData);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(_saveFilePath);
        SaveData save = JsonUtility.FromJson<SaveData>(jsonData);
        // managers will read data from save
        OnLoad?.Invoke(save);
    }
}
