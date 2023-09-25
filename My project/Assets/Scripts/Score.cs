using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("SHOW SCORE POPUP")]
    [SerializeField] GameObject popUp;
    [SerializeField] public GameObject tryAgain;

    [Header("HIDE OBJECT WHEN ENDGAME")]
    [SerializeField] List<GameObject> hide = new List<GameObject>();

    [Header("EFFECT")]
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    public GameObject badEffect;


    [Header("SCORE DATA")]
    public ScoreSetting point;
    public static Score instance;

    [Header("TEXT")]
    public TMP_Text MissNoteScoreText;
    public TMP_Text GoodScoreText;
    public TMP_Text PerfectScoreText;
    public TMP_Text TotalScoreText;
    public TMP_Text ShowScoreText;
    public TMP_Text BadScoreText;
    public TMP_Text ComboText;
    public TMP_Text maxComboText;
    public TMP_Text coinsText;

    PlayerData playerData;
    ThemeData bg;
    ThemeBgInfo bgInfo;
    bool equip = false;
    public enum GetScore
    {
        Miss,
        Good,
        Perfect,
        Bad,
        Combo,
        ResetCombo
    }

    [HideInInspector]
    public int TotalScore = 0;

    int MissNoteScore = 0;
    int GoodScore = 0;
    int PerfectScore = 0;
    int BadScore = 0;
    int Combo = 0;
    int maxCombo = 0;
    int coinTotal = 0;

    CurrencyData currencyData;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerData = ServerApi.Load();
        ServerApi.GetStorageButtonSkinData((d) => { bg = d; }, (e) => { });

        for (int i = 0; i < bg.bgData.Count; i++)
        {
            if (bg.bgData[i].ID == playerData.bgSkin)
            {
                equip = true;
                bgInfo = bg.bgData[i];
                break;
            }
        }

        goodEffect.GetComponent<SpriteRenderer>().sprite = bgInfo.good;
        perfectEffect.GetComponent<SpriteRenderer>().sprite = bgInfo.perfect;
        missEffect.GetComponent<SpriteRenderer>().sprite = bgInfo.miss;
        badEffect.GetComponent<SpriteRenderer>().sprite = bgInfo.bad;

        if (bgInfo.ID == "BG001")
        {
            goodEffect.transform.localScale = new Vector3(4f, 4f, 0);
            perfectEffect.transform.localScale = new Vector3(4f, 4f, 0);
            missEffect.transform.localScale = new Vector3(4f, 4f, 0);
            badEffect.transform.localScale = new Vector3(4f, 4f, 0);
        } else
        {
            
            goodEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0);
            perfectEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0);
            missEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0);
            badEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0);
        }
        



        BadScoreText.text = BadScore.ToString();
        MissNoteScoreText.text = MissNoteScore.ToString();
        GoodScoreText.text = GoodScore.ToString();
        PerfectScoreText.text = PerfectScore.ToString();
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();
        ComboText.text = "COMBO: x" + Combo.ToString();
        popUp.SetActive(false);
    }

    public void ScoreCalculationCase(GetScore get)
    {
        switch (get)
        {
            case GetScore.Miss:
                MissNoteScore += 1;
                coinTotal += 0;
                TotalScore -= point.missScore;
                MissNoteScoreText.text = $"{MissNoteScore}";
                Instantiate(missEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Good:
                GoodScore += 1;
                coinTotal += 2;
                TotalScore += point.goodScore;
                GoodScoreText.text = $"{GoodScore}";
                Instantiate(goodEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Perfect:
                PerfectScore += 1;
                coinTotal += 3;
                TotalScore += point.perfectScore;
                PerfectScoreText.text = $"{PerfectScore}";
                Instantiate(perfectEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Bad:
                BadScore += 1;
                coinTotal += 1;
                TotalScore -= point.badScore;
                BadScoreText.text = $"{BadScore}";
                Instantiate(badEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;


            case GetScore.Combo:
                Combo += 1;
                ComboText.text = $"COMBO: x{Combo}";
                break;

            case GetScore.ResetCombo:

                if (Combo > maxCombo)
                {
                    maxCombo = Combo;
                }
                Combo = 0;
                ComboText.text = $"COMBO: x{Combo}";
                break;

        }
        CheckTotalScore();
    }

    public void CheckTotalScore()
    {

        if (TotalScore < 0)
        {
            TotalScore = 0;
        }
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();
    }

    public void ShowScore()
    {
        popUp.SetActive(true);
        if (bgInfo.ID == "BG001")
        {
            popUp.GetComponent<Image>().sprite = MusicButton.get.bgSong;
        } else
        {
            popUp.GetComponent<Image>().sprite = bgInfo.bgImg;
        }

        if (TotalScore >= 0)
        {
            
            coinsText.text = coinTotal.ToString();
            playerData.coins += int.Parse(coinsText.text);
            ShowScoreText.text = TotalScore.ToString();
            maxComboText.text = maxCombo.ToString();

        }

        if (maxCombo < Combo)
        {
            maxCombo = Combo;
        }

        for (int i = 0; i < hide.Count; i++)
        {
            hide[i].SetActive(false);
        }

        Time.timeScale = 0;
        if (TotalScore < 0)
        {
            TotalScore = 0;
        }

        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();
        playerData.UpdateScore(MusicButton.get.idSong, MenuButton.selectMode, TotalScore);
        ServerApi.Save();
    }


}
