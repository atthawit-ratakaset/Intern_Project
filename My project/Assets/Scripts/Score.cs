using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TMP_Text MissNoteScoreText;
    public TMP_Text GoodScoreText;
    public  TMP_Text PerfectScoreText;
    public TMP_Text MissScoreText;
    public TMP_Text TotalScoreText;
    
    int TotalScore = 0;
    int MissNoteScore = 0;
    int GoodScore = 0;
    int PerfectScore = 0;
    int MissScore = 0;

    private void Awake(){
        instance = this;
    }
    
    void Start()
    {
        MissNoteScoreText.text = "MISS NOTE: " + MissNoteScore.ToString();
        GoodScoreText.text = "GOOD: " + GoodScore.ToString();
        PerfectScoreText.text = "PERFECT: " + PerfectScore.ToString();
        MissScoreText.text = "MISS: " + MissScore.ToString();
        TotalScoreText.text = "SCORE: " + TotalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TotalScoreText.text = "SCORE: " + TotalScore.ToString();
        if (TotalScore < 0) {
            TotalScore = 0;
        }
    }

    public void AddMissNotePoint(){
        MissNoteScore += 1;
        TotalScore -= 10;
        MissNoteScoreText.text = "MISS NOTE: " + MissNoteScore.ToString();
    }

    public void AddGoodScore(){
        GoodScore += 1;
        TotalScore += 10;
        GoodScoreText.text = "GOOD: " + GoodScore.ToString();
    }

    public void AddPerfectScore(){
        PerfectScore += 1;
        TotalScore += 20;
        PerfectScoreText.text = "PERFECT: " + PerfectScore.ToString();
    }

    public void AddMissScore(){
        MissScore += 1;
        TotalScore -= 10;
        MissScoreText.text = "MISS: " + MissScore.ToString();
    }
}
