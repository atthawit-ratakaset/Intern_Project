using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{   
    public void Resume() {
        Time.timeScale = 1f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio) {
            a.Play();
        }
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

    public void Song1() {
        SceneManager.LoadScene(2);
    }

    public void Song2() {
        SceneManager.LoadScene(3);
    }
}
