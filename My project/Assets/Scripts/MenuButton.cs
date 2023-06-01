using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    public int selectMode = 0;

    void Start()
    {
        instance = this;

    }

    public void GetMode(int mode)
    {
        selectMode = mode;
        SceneManager.LoadScene("PlayScene");
    }

    public void Resume() {
        ContinousGame.instance.Coutinous();
    }

    public void Pause() {
        Time.timeScale = 0f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio) {
            a.Pause();
        }
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReturnMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GetCurrentBuildIndex());
    }


    
}
