using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource gameMusic;
    PlayerData playerData;
    public static MusicScript instance;
    AudioClip clip;
    public float musicDelay;
    private float musicVolum = 1f;

    private void Awake()
    {
        instance = this;
        musicDelay = MusicButton.get.delay;
        clip = MusicButton.get.song;
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }

    void Start()
    {
        playerData = ServerApi.Load();
        if (playerData.allScore.Count == 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            gameMusic.PlayDelayed(musicDelay);
        }

    }

    private void Update()
    {
        gameMusic.volume = musicVolum;
    }

    public void StopMusic()
    {
        gameMusic.Stop();
    }

    public void SetVolum(float vol)
    {
        musicVolum = vol;
    }

}
