using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMusic : MonoBehaviour
{   

    public void GetSong(AudioSource audio) {
        GetValue.song = audio;
    }

    public void GetMode(int mode) {
        GetValue.mode = mode;
        SceneManager.LoadScene(2);
    }

}
