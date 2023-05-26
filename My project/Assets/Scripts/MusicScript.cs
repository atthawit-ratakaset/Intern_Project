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
        musicDelay = GetValue.delay;
        clip = GetValue.song;
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }
    // Start is called before the first frame update
    void Start()
    {   
        gameMusic.PlayDelayed(musicDelay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMusic() {
        gameMusic.Stop();
    }

}
