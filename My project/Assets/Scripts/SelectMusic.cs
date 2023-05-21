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
        SceneManager.LoadScene(2);
    }

    public void GetSong(AudioSource audio) {
        GetValue.audio = audio;
    }
}
