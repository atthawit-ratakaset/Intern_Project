using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "ThemeData", menuName = "ThemeItemInfo/ThemeData", order = 0)]

public class ThemeData : ScriptableObject
{
    public string saveKey;
    public List<ThemeButtonSkinInfo> skinData;


    public void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
        Debug.Log("overwrite data"); 
    }


    public void Save()
    {
        if (saveKey.Equals(""))
            saveKey = this.name;

        Debug.Log("save.....");
        string jsonData = JsonUtility.ToJson(this, true);
        Debug.Log(jsonData);
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();
    
    }

    public void Remove(ThemeButtonSkinInfo name)
    {
        skinData.Remove(name);
    }

    public void Add(ThemeButtonSkinInfo name)
    {
        skinData.Add(name);
    }

    public void Save(ThemeData themeData)
    {
        skinData = themeData.skinData;
    }
}
