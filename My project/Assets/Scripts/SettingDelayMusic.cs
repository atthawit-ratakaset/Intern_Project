using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDelayMusic : MonoBehaviour
{
    AudioSource gameMusic;
    AudioClip clip;
    public float musicDelay;

    private void Awake()
    {
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }

    void Start()
    {
        gameMusic.PlayDelayed(musicDelay);

    }
}
