using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "My project/GetValue", order = 0)]
public class GetValue : ScriptableObject {
    public string songName;
    public AudioClip song;
    public List<NoteData> Easy;
    public List<NoteData> Normal;
    public List<NoteData> Hard;

    public float delay;
    public float timerEasy;
    public float timerNormal;
    public float timerHard;
    public float easySpeed;
    public float normalSpeed;
    public float hardSpeed;
}
