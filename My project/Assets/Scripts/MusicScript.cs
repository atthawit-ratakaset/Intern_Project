using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{   
    AudioSource gameMusic;
    public static MusicScript instance;
    AudioClip clip;
    public float musicDelay;

    private void Awake() {
        instance = this;
        musicDelay = MusicButton.instance.musicData.delay;
        clip = MusicButton.get.song;
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }

    void Start()
    {
        
        gameMusic.PlayDelayed(musicDelay);

    }

    public void StopMusic() {
        gameMusic.Stop();
    }

}
