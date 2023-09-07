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
    public TMP_Text highScore;
    public TMP_Text highScoreLoad;
    public TMP_Text playCounts;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;
    public TMP_Text levelMode;

    [Header("ModeSprite")]
    public GameObject easy;
    public Button easyBtn;
    public GameObject normal;
    public Button normalBtn;
    public GameObject hard;
    public Button hardBtn;

    [HideInInspector]
    public static int selectMode;

    [HideInInspector]
    public string scene;

    void Start()
    {
        instance = this;
        if (selectMode == 0)
        {
            easyBtn.onClick.Invoke();
        } else if (selectMode == 1)
        {
            normalBtn.onClick.Invoke();
        } else if (selectMode == 2)
        {
            hardBtn.onClick.Invoke();
        }
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
        easy.SetActive(true);
        normal.SetActive(false);
        hard.SetActive(false);
        if (MusicButton.get.alreadyBuy == false)
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }
        else
        {
            if (MusicButton.get.highScoreEasy <= 0)
            {
                highScore.text = "No record";
                highScoreLoad.text = "No record";
            }
            else if (MusicButton.get.highScoreEasy > 0)
            {
                highScore.text = MusicButton.get.highScoreEasy.ToString();
                
            }

            if (MusicButton.get.playCountEasy <= 0)
            {
                playCounts.text = "No record";
            }
            else if (MusicButton.get.playCountEasy > 0)
            {
                playCounts.text = MusicButton.get.playCountEasy.ToString();
            }
        }
    }

    public void GetNormalMode()
    {
        selectMode = 1;
        easy.SetActive(false);
        normal.SetActive(true);
        hard.SetActive(false);
        if (MusicButton.get.alreadyBuy == false)
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }
        else
        {
            if (MusicButton.get.highScoreNormal <= 0)
            {
                highScore.text = "No record";
                highScoreLoad.text = "No record";
            }
            else if (MusicButton.get.highScoreNormal > 0)
            {
                highScore.text = MusicButton.get.highScoreNormal.ToString();
                
            }

            if (MusicButton.get.playCountNormal <= 0)
            {
                playCounts.text = "No record";
            }
            else if (MusicButton.get.playCountNormal > 0)
            {
                playCounts.text = MusicButton.get.playCountNormal.ToString();
            }
        }
    }

    public void GetHardMode()
    {
        selectMode = 2;
        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(true);
        if (MusicButton.get.alreadyBuy == false)
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }
        else
        {
            if (MusicButton.get.highScoreHard <= 0)
            {
                highScore.text = "No record";
                highScoreLoad.text = "No record";
            }
            else if (MusicButton.get.highScoreHard > 0)
            {
                highScore.text = MusicButton.get.highScoreHard.ToString();
                
            }

            if (MusicButton.get.playCountHard <= 0)
            {
                playCounts.text = "No record";
            }
            else if (MusicButton.get.playCountHard > 0)
            {
                playCounts.text = MusicButton.get.playCountHard.ToString();
            }
        }
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
                currencyData.Save();
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
                highScoreLoad.text = MusicButton.get.highScoreEasy.ToString();
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
                highScoreLoad.text = MusicButton.get.highScoreNormal.ToString();
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
                highScoreLoad.text = MusicButton.get.highScoreHard.ToString();
            }
            yield return null;
        }
    }


    
}
