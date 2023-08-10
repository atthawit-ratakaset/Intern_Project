using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlaySceneMenu : MonoBehaviour
{
    public static PlaySceneMenu instance;
    public GameObject setting;
    public GameObject pause;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;
    public TMP_Text levelMode;

    [HideInInspector]
    public int selectMode;

    [HideInInspector]
    public string scene;

    [HideInInspector]
    public int menu = 1;

    void Start()
    {
        instance = this;
        
    }

    public void Resume()
    {
        ContinousGame.instance.Coutinous();
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio)
        {
            a.Pause();
        }
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReturnMenuMusic()
    {
        menu = SetObject.instance.whatScene + 1;
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");

    }

    public void ReturnToLobby()
    {
        menu = 0;
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");
    }

    public IEnumerator LoadScene()
    {
        load.SetActive(true);
        selectMode = GameControl.instance.getMode;
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
            if (selectMode == 0)
            {
                levelMode.text = "Easy";
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
            }
            yield return null;
        }
    }

    public void Retry()
    {
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
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
            if (selectMode == 0)
            {
                levelMode.text = "Easy";
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
            }
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
