using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{   
    AudioSource gameMusic;
    public static MusicScript instance;
    AudioClip clip;
    private float musicDelay;

    private void Awake() {
        instance = this;
        Debug.Log(MusicButton.get);
        musicDelay = MusicButton.get.delay;
        clip = MusicButton.get.song;
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }

    void Start()
    {
        Debug.Log(musicDelay);
        gameMusic.PlayDelayed(musicDelay);

    }

    public void StopMusic() {
        gameMusic.Stop();
    }

}
