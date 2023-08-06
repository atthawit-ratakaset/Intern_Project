using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    public GameObject setting;
    public GameObject pause;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;

    [HideInInspector]
    public int selectMode;

    [HideInInspector]
    public string scene;

    void Start()
    {
        instance = this;

    }

    public void GetMode(int mode)
    {
        selectMode = mode;
        scene = "PlayScene1";
        StartCoroutine("LoadScene");
    }
    
    public IEnumerator LoadScene()
    {
        load.SetActive(true);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            yield return null;
        }
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
        scene = "Menu";
        StartCoroutine("LoadScene");
    }

    public void Retry() {
        Time.timeScale = 1f;
        StartCoroutine("LoadRetry");
        selectMode = GameControl.instance.getMode;
    }

    public IEnumerator LoadRetry()
    {
        load.SetActive(true);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(GetCurrentBuildIndex(), LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.fillAmount = loadScene.progress;
            yield return null;
        }
    }

    public void SettingVoloum()
    {
        pause.SetActive(false);
        setting.SetActive(true);
    }

    public void BackToPause()
    {
        pause.SetActive(true);
        setting.SetActive(false);
    }

    
}
