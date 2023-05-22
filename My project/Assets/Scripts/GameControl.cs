using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{   
    [SerializeField] GameObject CheckHp;
    int numSongNote;
    public static GameControl instance;
    AudioSource musicSong;
    bool have = false;

    void Awake() {
        instance = this;
        musicSong = GetValue.song;
        numSongNote = GetValue.musicSongNote;
        have = GetValue.appear;
    }
    // Start is called before the first frame update
    void Start()
    {   
        Instantiate(SelectMusic.instance.obj[numSongNote], SelectMusic.instance.obj[numSongNote].transform.position, Quaternion.identity);
        Instantiate(musicSong, musicSong.transform.position, Quaternion.identity);
        if (have) {
            CheckHp.SetActive(true);
        } else {
            CheckHp.SetActive(false);
        }
    }

    public void CheckScene() {
        if (have) {
            HpBar.instance.LoseHp();
        }
    }
}
