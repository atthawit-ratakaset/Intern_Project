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

    [Header("Game")]
    public GameObject playPopUp;
    public TMP_Text musicName;
    public Button play;
    public Button cancel;
    public TMP_Text highScore;
    public TMP_Text highScoreLoad;
    public TMP_Text modeText;
    public TMP_Text playCounts;
    public TMP_Text timerTextMinutes;
    public TMP_Text modeRec;
    public TMP_Text modeRec1;
    private float timerTime;
    private int minutesInt;
    private int secondsInt;
    PlayerData playerData;
    bool x = false;

    [Header("Bluetooth And Setting")]
    public Image onOffBtn;
    public Sprite onImg;
    public Sprite offImg;
    public static bool bluetoothOn;
    public GameObject bluetoothShow1;
    public GameObject bluetoothShow2;
    public GameObject gameGuide;
    public Button gameGuideOk;

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
        gameGuide.SetActive(false);
        playPopUp.SetActive(false);
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
        modeText.text = "Mode : Easy";
        modeRec.text = "Easy Mode low speed";
        modeRec1.text = "Easy Mode low speed";
        easy.SetActive(true);
        normal.SetActive(false);
        hard.SetActive(false);
        timerTime = MusicButton.get.timerEasy + MusicButton.get.delay;
        Timer(timerTime);
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
        modeText.text = "Mode : Normal";
        modeRec.text = "Normal Mode normal speed";
        modeRec1.text = "Normal Mode normal speed";
        easy.SetActive(false);
        normal.SetActive(true);
        hard.SetActive(false);
        timerTime = MusicButton.get.timerNormal + MusicButton.get.delay;
        Timer(timerTime);
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
        modeText.text = "Mode : Hard";
        modeRec.text = "Hard Mode high speed";
        modeRec1.text = "Hard Mode high speed";
        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(true);
        timerTime = MusicButton.get.timerHard + MusicButton.get.delay;
        Timer(timerTime);
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

    public void Timer(float time)
    {
        minutesInt = (int)time / 60;
        secondsInt = (int)time % 60;
        timerTextMinutes.text = $"{minutesInt} : {secondsInt}";
    }


    public void PlayPopUp()
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
            playPopUp.SetActive(true);
            musicName.text = MusicButton.get.songName;
            play.onClick.AddListener(delegate () { Test(); });
            cancel.onClick.AddListener(delegate () { PlayPopUpCancel(); });
        }
        else
        {
            AlertPopShow();
        }
    }


    public void PlayPopUpCancel()
    {
        playPopUp.SetActive(false);
    }

    public void Test()
    {
        PlayerData playerData = ServerApi.Load();
        playPopUp.SetActive(false);
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
            GameManager.instance.ConnectBLE();
            if (GameManager.isConnected)
            {
                onOffBtn.sprite = onImg;
                bluetoothShow1.SetActive(true);
                bluetoothShow2.SetActive(true);
                bluetoothOn = true;
            }

        }
        else if (bluetoothOn == true)
        {   
            GameManager.instance.StopConnectBLE();
            if (!GameManager.isConnected)
            {
                onOffBtn.sprite = offImg;
                bluetoothShow1.SetActive(false);
                bluetoothShow2.SetActive(false);
                bluetoothOn = false;
            }
        }
    }

    public void GuideBook()
    {
        gameGuide.SetActive(true);
        gameGuideOk.onClick.RemoveAllListeners();
        gameGuideOk.onClick.AddListener(delegate () { CloseGuideGame(); });
    }

    public void CloseGuideGame()
    {
        gameGuide.SetActive(false);
        GuideGame.instance.whatPage = 1;
        GuideGame.instance.CheckPage();
    }
}
