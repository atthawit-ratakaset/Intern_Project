using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    AudioSource gameMusic;
    public static MusicScript instance;
    public float musicDelay;

    private void Awake() {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        gameMusic.PlayDelayed(musicDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMusic() {
        Destroy(gameMusic);
    }

}
