using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "My project/GetValue", order = 0)]
public class GetValue : ScriptableObject
{
    public string idSong;
    public string songName;
    public Sprite image;
    public Sprite imageLock;
    public Sprite bgSong;
    public AudioClip song;
    public List<NoteData> Easy;
    public List<NoteData> Normal;
    public List<NoteData> Hard;
    public List<NoteData> Event;


    [Header("Setting In Game")]
    public float delay;
    public float timerEasy;
    public float timerNormal;
    public float timerHard;
    public float easySpeed;
    public float normalSpeed;
    public float hardSpeed;
    public float eventSpeed;
    public int targetScore;

    [Header("Shop Setting")]
    public string songInfo;
    public int price;
    public Sprite currencyType;


}
