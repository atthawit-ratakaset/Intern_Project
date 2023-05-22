using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMusic : MonoBehaviour
{   
    public GameObject[] obj;
    public static SelectMusic instance;


    void Awake() {
        instance = this;
    }

    public void PlayScene(int numSong) {
        GetValue.musicSongNote = numSong;
    }

    public void GetSong(AudioSource audio) {
        GetValue.song = audio;
    }

    public void GetMode(bool hard) {
        GetValue.appear = hard;
        SceneManager.LoadScene(2);
    }
}
