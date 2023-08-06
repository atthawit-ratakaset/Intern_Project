using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   
    [Header ("SHOW SCORE POPUP")]
    [SerializeField] GameObject popUp;

    [Header ("HIDE OBJECT WHEN ENDGAME")]
    [SerializeField] List<GameObject> hide = new List<GameObject>();

    [Header ("EFFECT")]
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    public GameObject badEffect;


    [Header ("SCORE DATA")]
    public ScoreSetting point;
    public static Score instance;

    [Header ("TEXT")]
    public TMP_Text MissNoteScoreText;
    public TMP_Text GoodScoreText;
    public  TMP_Text PerfectScoreText;
    public TMP_Text MissScoreText;
    public TMP_Text TotalScoreText;
    public TMP_Text ShowScoreText;
    public TMP_Text BadScoreText;
    public TMP_Text ComboText;
    
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
    int MissScore = 0;
    int BadScore = 0;
    int Combo = 0;

    private void Awake(){
        instance = this;
    }
    
    void Start()
    {
        BadScoreText.text = "BAD: " + BadScore.ToString();
        MissNoteScoreText.text = "MISS NOTE: " + MissNoteScore.ToString();
        GoodScoreText.text = "GOOD: " + GoodScore.ToString();
        PerfectScoreText.text = "PERFECT: " + PerfectScore.ToString();
        MissScoreText.text = "MISS: " + MissScore.ToString();
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
                TotalScore -= point.missScore;
                MissNoteScoreText.text = $"MISS NOTE: {MissNoteScore}";
                Instantiate(missEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Good:
                GoodScore += 1;
                TotalScore += point.goodScore;
                GoodScoreText.text = $"GOOD: {GoodScore}";
                Instantiate(goodEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Perfect:
                PerfectScore += 1;
                TotalScore += point.perfectScore;
                PerfectScoreText.text = $"PERFECT: {PerfectScore}";
                Instantiate(perfectEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Bad:
                BadScore += 1;
                TotalScore -= point.badScore;
                BadScoreText.text = $"BAD: {BadScore}";
                Instantiate(badEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;


            case GetScore.Combo:
                Combo += 1;
                ComboText.text = $"COMBO: x{Combo}";
                break;

            case GetScore.ResetCombo:
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

    public void ShowScore() {
        popUp.SetActive(true);
        for(int i = 0; i < hide.Count; i++)
        {
            hide[i].SetActive(false);
        }
        Time.timeScale = 0;
        if (TotalScore < 0) {
            TotalScore = 0;
        }
        ShowScoreText.text = TotalScore.ToString();
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();

    }
    

}
