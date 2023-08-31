using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MusicData", menuName = "My project/AllMusicData", order = 0)]

public class AllMusicData : ScriptableObject
{
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
}
