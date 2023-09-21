using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeData", menuName = "ThemeItemInfo/ThemeData", order = 0)]

public class ThemeData : ScriptableObject
{
    public string saveKey;
    public List<ThemeButtonSkinInfo> skinData;
    public List<ThemeBgInfo> bgData;

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
    }


    public void Save()
    {
        if (saveKey.Equals(""))
            saveKey = this.name;

        string jsonData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();

    }

    public void RemoveBtnSkin(ThemeButtonSkinInfo name)
    {
        skinData.Remove(name);
    }

    public void AddBtnSkin(ThemeButtonSkinInfo name)
    {
        skinData.Add(name);
    }

    public void RemoveBgSkin(ThemeBgInfo name)
    {
        bgData.Remove(name);
    }

    public void AddBgSkin(ThemeBgInfo name)
    {
        bgData.Add(name);
    }

    public void Save(ThemeData themeData)
    {
        skinData = themeData.skinData;
    }
}
