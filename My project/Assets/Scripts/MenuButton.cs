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

    [Header("ModeSprite")]
    public Image easyImage;
    public Sprite easySelect;
    public Sprite easyQuit;
    public Image normalImage;
    public Sprite normalSelect;
    public Sprite normalQuit;
    public Image hardImage;
    public Sprite hardSelect;
    public Sprite hardQuit;

    [HideInInspector]
    public int selectMode;

    [HideInInspector]
    public string scene;

    void Start()
    {
        instance = this;

    }

    public void PlayScene()
    {
        SceneManager.LoadScene("PlayScene1");
        //scene = "PlayScene1";
        //StartCoroutine("LoadScene");
    }

    public void GetEasyMode()
    {
        selectMode = 0;
        easyImage.GetComponent<Image>().sprite = easySelect;
        normalImage.GetComponent<Image>().sprite = normalQuit;
        hardImage.GetComponent<Image>().sprite = hardQuit;
    }

    public void GetNormalMode()
    {
        selectMode = 1;
        easyImage.GetComponent<Image>().sprite = easyQuit;
        normalImage.GetComponent<Image>().sprite = normalSelect;
        hardImage.GetComponent<Image>().sprite = hardQuit;
    }

    public void GetHardMode()
    {
        selectMode = 2;
        easyImage.GetComponent<Image>().sprite = easyQuit;
        normalImage.GetComponent<Image>().sprite = normalQuit;
        hardImage.GetComponent<Image>().sprite = hardSelect;
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
