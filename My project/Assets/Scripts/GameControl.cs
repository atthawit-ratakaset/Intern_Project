using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{      
    int numSongNote;
    AudioSource audio;

    void Awake() {
        audio = GetValue.audio;
        numSongNote = GetValue.musicSongNote;
    }
    // Start is called before the first frame update
    void Start()
    {   
        Instantiate(SelectMusic.instance.obj[numSongNote], SelectMusic.instance.obj[numSongNote].transform.position, Quaternion.identity);
        Instantiate(audio, audio.transform.position, Quaternion.identity);
    }


}
