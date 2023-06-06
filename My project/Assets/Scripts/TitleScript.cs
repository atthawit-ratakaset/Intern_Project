using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject gameName, play, credits, aboutUs;

    void start()
    {
        gameName.SetActive(true);
        play.SetActive(false);
        credits.SetActive(false);
        aboutUs.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowCredit()
    {
        gameName.SetActive(false);
        play.SetActive(false);
        credits.SetActive(false);
        aboutUs.SetActive(true);
    }

    public void Back()
    {
        gameName.SetActive(true);
        play.SetActive(true);
        credits.SetActive(true);
        aboutUs.SetActive(false);
    }
}
