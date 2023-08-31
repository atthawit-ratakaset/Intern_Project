using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    CurrencyData currencyData;
    int currentEnergy;
    public GameObject alertPopUp;
    public TMP_Text alertText;
    public TMP_Text name;

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


    public void AlertPopShow()
    {
        alertPopUp.SetActive(true);
        if (MusicButton.get.alreadyBuy == true)
        {
            name.text = null; 
            alertText.text = $"Not enough Energy, want to buy more?";
        }
        else
        {
            name.text = MusicButton.get.songName;
            alertText.text = $"You do not have this music! \n Do you want to buy?";
        }
    }

    public void Cancel()
    {
        alertPopUp.SetActive(false);
        
    }

    public void AlertBuy()
    {
        Cancel();
        if (MusicButton.get.alreadyBuy == true)
        {
            SetObject.instance.EnergyMenu();
        }
        else
        {
            SetObject.instance.MusicMenu();
        }
        name.text = null;
      
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

    public void Test()
    {
        ServerApi.GetPlayerData((d) => { currencyData = d; }, (e) => { });
        currentEnergy = currencyData.energy;
        if (MusicButton.get.alreadyBuy == true)
        {
            if (currentEnergy >= 1)
            {
                currentEnergy--;
                currencyData.SaveEnergy(currentEnergy);

                if (MusicButton.get != null)
                {
                    scene = "PlayScene1";
                    StartCoroutine("LoadScene");
                }

            }
            else
            {
                AlertPopShow();
                Debug.Log("Don't have Energy!");
            }
        }
        else if (MusicButton.get.alreadyBuy == false)
        {
            AlertPopShow();
            Debug.Log("You do not have this music");
        }
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
