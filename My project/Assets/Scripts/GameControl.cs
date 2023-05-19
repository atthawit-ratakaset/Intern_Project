using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{      
    int numSong;
    AudioSource audio;
    void Awake() {
        numSong = GetValue.musicSongs;
        audio = GetValue.audio;
    }
    // Start is called before the first frame update
    void Start()
    {   
        Instantiate(MenuButton.instance.obj[numSong], MenuButton.instance.obj[numSong].transform.position, Quaternion.identity);
        Instantiate(audio, audio.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
