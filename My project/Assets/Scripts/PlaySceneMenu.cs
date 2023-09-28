using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySceneMenu : MonoBehaviour
{
    public static PlaySceneMenu instance;
    public GameObject setting;
    public GameObject pause;
    public GameObject popUpFinsh;
    public TMP_Text finshBuyText;
    public GameObject alertPopUp;
    public TMP_Text currencyTypes;
    PlayerData playerData;
    int currentEnergy;
    int currentDiamond;
    ThemeData bg;
    public ThemeBgInfo bgInfo;

    public GameObject guideGame;

    [Header("HpBar")]
    public Image hpInside;
    public Image hpBar;
    public Image hpIcon;

    [Header("LoadScene")]
    public Image loadbg;
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
        playerData = ServerApi.Load();
        selectMode = GameControl.instance.getMode;
        if (playerData.allScore.Count == 0)
        {
            Time.timeScale = 0;
            guideGame.SetActive(true);
            
        } else
        {
            guideGame.SetActive(false);
        }

        ServerApi.GetStorageButtonSkinData((d) => { bg = d; }, (e) => { });

        for (int i = 0; i < bg.bgData.Count; i++)
        {
            if (bg.bgData[i].ID == playerData.bgSkin)
            {

                bgInfo = bg.bgData[i];
                break;
            }
        }


        if (bgInfo.ID == "BG001")
        {
            hpInside.transform.localPosition = new Vector3(17f, -15f, 0);
        }
        else
        {
            hpInside.transform.localPosition = new Vector3(1.5f, 10f, 0);

        }

        hpInside.sprite = bgInfo.hpLine;
        hpBar.sprite = bgInfo.hpBar;
        hpIcon.sprite = bgInfo.hpIcon;

        ScoreData songScore = playerData.allScore.Find(s => s.id == MusicButton.get.idSong && s.mode == selectMode);
        if (songScore != null)
        {
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
            score.text = songScore.score.ToString();
        }
        else
        {
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
            score.text = "No record";
        }
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
        if (GameManager.isConnected)
        {
            if (UpButtonGame.instance.checkId == 1)
            {
                BluetoothService.WritetoBluetooth("4");
            }
        }
        menu = SetObject.instance.whatScene + 1;
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");



    }

    public void ReturnToLobby()
    {
        menu = 0;
        if (GameManager.isConnected)
        {
            if (UpButtonGame.instance.checkId == 1)
            {
                BluetoothService.WritetoBluetooth("4");
            }
        }
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");
    }

    public IEnumerator LoadScene()
    {
        load.SetActive(true);
        ServerApi.GetStorageButtonSkinData((d) => { bg = d; }, (e) => { });

        for (int i = 0; i < bg.bgData.Count; i++)
        {
            if (bg.bgData[i].ID == playerData.bgSkin)
            {
                bgInfo = bg.bgData[i];
                break;
            }
        }
        if (bgInfo.ID == "BG001" || bgInfo.bgImg == null)
        {
            loadbg.sprite = MusicButton.get.bgSong;
        }
        else
        {
            loadbg.sprite = bgInfo.bgImg;
        }

        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;




            yield return null;
        }
    }

    public void AlertBuy()
    {
        alertPopUp.SetActive(false);

        currentEnergy = playerData.energy;
        currentDiamond = playerData.diamonds;
        if (currentDiamond >= 10)
        {
            currentDiamond -= 10;
            currentEnergy += 5;
            playerData.SaveDiamonds(currentDiamond);
            playerData.SaveEnergy(currentEnergy);
            ServerApi.Save();
            alertPopUp.SetActive(false);
            popUpFinsh.SetActive(true);
            finshBuyText.text = "Complete Buy!";
        }
        else
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
        if (GameManager.isConnected)
        {
            if (UpButtonGame.instance.checkId == 1)
            {
                BluetoothService.WritetoBluetooth("4");
            }
        }
        if (playerData.energy >= 1)
        {
            playerData.energy--;
            Debug.Log(playerData.energy);
            ServerApi.Save();
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
        ServerApi.GetStorageButtonSkinData((d) => { bg = d; }, (e) => { });

        for (int i = 0; i < bg.bgData.Count; i++)
        {
            if (bg.bgData[i].ID == playerData.bgSkin)
            {
                bgInfo = bg.bgData[i];
                break;
            }
        }

        if (bgInfo.ID == "BG001" || bgInfo.bgImg == null)
        {
            loadbg.sprite = MusicButton.get.bgSong;
        }
        else
        {
            loadbg.sprite = bgInfo.bgImg;
        }
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(GetCurrentBuildIndex(), LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
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
