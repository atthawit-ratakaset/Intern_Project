using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class PlaySceneMenu : MonoBehaviour
{
    public static PlaySceneMenu instance;
    public GameObject setting;
    public GameObject pause;
    public GameObject popUpFinsh;
    public TMP_Text finshBuyText;
    public GameObject alertPopUp;
    public TMP_Text currencyTypes;
    CurrencyData playerData;
    int currentEnergy;
    int currentDiamond;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;
    public TMP_Text levelMode;
    public TMP_Text score;

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
                score.text = MusicButton.get.highScoreEasy.ToString();
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
                score.text = MusicButton.get.highScoreNormal.ToString();
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
                score.text = MusicButton.get.highScoreHard.ToString();
            }
            yield return null;
        }
    }

    public void AlertBuy()
    {
        alertPopUp.SetActive(false);
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });
        currentEnergy = playerData.energy;
        currentDiamond = playerData.diamonds;
        if (currentDiamond >= 10)
        {
            currentDiamond -= 10;
            currentEnergy += 5;
            playerData.SaveDiamonds(currentDiamond);
            playerData.SaveEnergy(currentEnergy);
            playerData.Save();
            alertPopUp.SetActive(false);
            popUpFinsh.SetActive(true);
            finshBuyText.text = "Complete Buy!";
        } else
        {
            popUpFinsh.SetActive(true);
            finshBuyText.text = "You do not have enough diamond to buy!";
        }
    }

    public void CloseFinshPopUp()
    {
        popUpFinsh.SetActive(false);
    }

    public void Retry()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });
        currentEnergy = playerData.energy;
        if (currentEnergy >= 1)
        {
            currentEnergy--;
          
            playerData.SaveEnergy(currentEnergy);
            playerData.Save();
            //if (Energy.instance.isRestoring == false)
            //{
                //if (Energy.instance.currentEnergy + 1 == Energy.instance.maxEnergy)
                //{
                    //Energy.instance.nextEnergyTime = Energy.instance.AddDuration(DateTime.Now, Energy.instance.restoreDuration);
                //}

                //StartCoroutine(Energy.instance.RestoreEnergy());
            //}
            Time.timeScale = 1f;
            StartCoroutine("LoadRetry");
            selectMode = GameControl.instance.getMode;
        }
        else
        {
            alertPopUp.SetActive(true);
            currencyTypes.text = "Oop! Sorry Not enough energy \nDo you want to buy 5 energy use 10 dimonds?";

        }

    }

    public void CloseAlert()
    {
        alertPopUp.SetActive(false);
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
                score.text = MusicButton.get.highScoreEasy.ToString();
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
                score.text = MusicButton.get.highScoreNormal.ToString();
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
                score.text = MusicButton.get.highScoreHard.ToString();
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
