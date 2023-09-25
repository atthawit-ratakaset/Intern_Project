using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    public GameObject alertPopUp;
    public TMP_Text alertText;
    public TMP_Text name;
    public TMP_Text highScore;
    public TMP_Text highScoreLoad;
    public TMP_Text playCounts;
    PlayerData playerData;
    bool x = false;

    [Header("Bluetooth")]
    public Image onOffBtn;
    public Sprite onImg;
    public Sprite offImg;
    public static bool bluetoothOn;
    public GameObject bluetoothShow1;
    public GameObject bluetoothShow2;

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
        playerData = ServerApi.Load();
        Debug.Log(bluetoothOn);
        if (bluetoothOn == true)
        {
            onOffBtn.sprite = onImg;
            bluetoothShow1.SetActive(true);
            bluetoothShow2.SetActive(true);
        }
        else if (bluetoothOn == false)
        {
            onOffBtn.sprite = offImg;
            bluetoothShow1.SetActive(false);
            bluetoothShow2.SetActive(false);
        }

    }


    public void AlertPopShow()
    {
        alertPopUp.SetActive(true);
        PlayerData playerData = ServerApi.Load();

        for (int i = 0; i < playerData.storageMusicData.Count; i++)
        {

            if (playerData.storageMusicData[i] == MusicButton.get.idSong)
            {
                x = true;
                break;
            }
            else
            {
                x = false;
            }


        }

        if (x == true)
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
        PlayerData playerData = ServerApi.Load();
        for (int i = 0; i < playerData.storageMusicData.Count; i++)
        {


            if (playerData.storageMusicData[i] == MusicButton.get.idSong)
            {
                x = true;
                break;
            }
            else
            {
                x = false;
            }


        }

        Cancel();
        if (x == true)
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
        ScoreData songScore = playerData.allScore.Find(s => s.id == MusicButton.get.idSong && s.mode == selectMode);
        if (songScore != null)
        {
            highScore.text = songScore.score.ToString();
            playCounts.text = songScore.playCount.ToString();
        }
        else
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }
    }

    public void GetNormalMode()
    {
        selectMode = 1;
        easy.SetActive(false);
        normal.SetActive(true);
        hard.SetActive(false);
        ScoreData songScore = playerData.allScore.Find(s => s.id == MusicButton.get.idSong && s.mode == selectMode);
        if (songScore != null)
        {
            highScore.text = songScore.score.ToString();
            playCounts.text = songScore.playCount.ToString();
        }
        else
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }

    }

    public void GetHardMode()
    {
        selectMode = 2;
        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(true);
        ScoreData songScore = playerData.allScore.Find(s => s.id == MusicButton.get.idSong && s.mode == selectMode);
        if (songScore != null)
        {
            highScore.text = songScore.score.ToString();
            playCounts.text = songScore.playCount.ToString();
        }
        else
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }

    }

    public void Test()
    {
        PlayerData playerData = ServerApi.Load();

        for (int i = 0; i < playerData.storageMusicData.Count; i++)
        {

            if (playerData.storageMusicData[i] == MusicButton.get.idSong)
            {
                x = true;
                break;
            }
            else
            {
                x = false;
            }

        }


        if (x == true)
        {
            if (playerData.energy >= 1)
            {   
                
                playerData.energy--;
                
                if (Energy.instance.isRestoring == false)
                {
                    
                    if (playerData.energy + 1 == Energy.instance.maxEnergy)
                    {
                        Energy.instance.nextEnergyTime = Energy.instance.AddDuration(DateTime.Now, Energy.instance.restoreDuration);
                    }

                    StartCoroutine(Energy.instance.RestoreEnergy());
                }

                if (MusicButton.get != null)
                {
                    scene = "PlayScene1";
                    StartCoroutine("LoadScene");
                }
                ServerApi.Save();
            }
            else
            {
                AlertPopShow();
                Debug.Log("Don't have Energy!");
            }
        }
        else if (x == false)
        {
            AlertPopShow();
            Debug.Log("You do not have this music");
        }
    }
    public IEnumerator LoadScene()
    {
        load.SetActive(true);
        ScoreData songScore = playerData.allScore.Find(s => s.id == MusicButton.get.idSong && s.mode == selectMode);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            SetObject.instance.loadBg.sprite = MusicButton.get.bgSong;
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
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
                highScoreLoad.text = songScore.score.ToString();
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
                highScoreLoad.text = "No record";
            }
            yield return null;
        }
    }


    public void TitleMenu()
    {
        SceneManager.LoadScene("Title");
        StateScene.menu = 0;
    }

    public void OnOffUpdate()
    {
        if (bluetoothOn == false)
        {
            onOffBtn.sprite = onImg;
            GameManager.instance.ConnectBLE();
            bluetoothShow1.SetActive(true);
            bluetoothShow2.SetActive(true);
            bluetoothOn = true;
        } else if (bluetoothOn == true)
        {
            onOffBtn.sprite = offImg;
            GameManager.instance.StopConnectBLE();
            bluetoothShow1.SetActive(false);
            bluetoothShow2.SetActive(false);
            bluetoothOn = false;
        }
    }
}
