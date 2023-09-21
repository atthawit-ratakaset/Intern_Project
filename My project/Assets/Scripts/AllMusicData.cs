using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MusicData", menuName = "My project/AllMusicData", order = 0)]

public class AllMusicData : ScriptableObject
{
    public string saveKey;
    public List<GetValue> getMusicData;

    public void Remove(GetValue name)
    {
        getMusicData.Remove(name);
    }

    public void Add(GetValue name)
    {
        getMusicData.Add(name);
    }

    public void Save(AllMusicData musicData)
    {
        getMusicData = musicData.getMusicData;
    }

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
}
