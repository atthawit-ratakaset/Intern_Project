using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   
    [SerializeField] GameObject popUp;
    [SerializeField] List<GameObject> hide = new List<GameObject>();
    public static Score instance;
    public TMP_Text MissNoteScoreText;
    public TMP_Text GoodScoreText;
    public  TMP_Text PerfectScoreText;
    public TMP_Text MissScoreText;
    public TMP_Text TotalScoreText;
    public TMP_Text ShowScoreText;
    public TMP_Text BadScoreText;
    public TMP_Text ComboText;
    
    int TotalScore = 0;
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
        TotalScoreText.text = "SCORE: " + TotalScore.ToString();
        ComboText.text = "COMBO: x" + Combo.ToString();
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
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

    public void AddBadScore(){
        BadScore += 1;
        TotalScore -= 10;
        BadScoreText.text = "BAD: " + BadScore.ToString();
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
        TotalScoreText.text = "SCORE: " + TotalScore.ToString();
    }

    public void AddCombo() {
        Combo += 1;
        ComboText.text = "COMBO: x" + Combo.ToString();
    }

    public void ReSetCombo() {
        Combo = 0;
        ComboText.text = "COMBO: x" + Combo.ToString();
    }
}
