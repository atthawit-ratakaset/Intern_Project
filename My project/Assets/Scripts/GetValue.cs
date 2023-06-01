using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "My project/GetValue", order = 0)]
public class GetValue : ScriptableObject {
    public string songName;
    public AudioClip song;
    public List<GameObject> Notes;
    public float delay;
    public float timerEasy;
    public float timerNormal;
    public float timerHard;
    
}
