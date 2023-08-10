using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;
    public TMP_Text levelMode;

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
        if (MusicButton.get != null)
        {
            scene = "PlayScene1";
            StartCoroutine("LoadScene");
        } else
        {
            Debug.Log("Please choose music");
        }
        
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


    
}
