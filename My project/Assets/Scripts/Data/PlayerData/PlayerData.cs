using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData
{
    public string saveKey = "PlayerData";
    public string playerName;
    public int energy;
    public int coins;
    public int diamonds;

    public List<string> storageButtonSkinData = new List<string>();
    public List<string> storageBgSkinData = new List<string>();
    public List<string> storageMusicData = new List<string>();
    public List<ScoreData> allScore = new List<ScoreData>();

    public string btnSkinData;
    public string bgSkin;
    public void SaveEnergy(int num)
    {
        energy = num;

    }

    public void SaveCoins(int num)
    {
        coins = num;
    }

    public void UpdateEnergy(TMP_Text energys)
    {
        energys.text = $"{energy.ToString()} / {Energy.instance.maxEnergy}";
    }

    public void UpdateCoins(TMP_Text coin)
    {
        coin.text = coins.ToString();
    }


    public void SaveDiamonds(int num)
    {
        diamonds = num;
    }

    public void UpdateDiamonds(TMP_Text diamond)
    {
        diamond.text = diamonds.ToString();
    }

    public void UpdateScore(string id, int mode, int score)
    {
        ScoreData scoreData = allScore.Find(s => s.id == id && s.mode == mode);
        if (scoreData != null)
        {

            if (scoreData.score >= score)
            {
                Debug.Log("SameScore");
            }
            else
            {
                scoreData.score = score;
            }
            scoreData.playCount++;

        }
        else
        {
            ScoreData newScoreData = new ScoreData();
            newScoreData.id = id;
            newScoreData.mode = mode;
            newScoreData.score = score;
            newScoreData.playCount = 1;
            allScore.Add(newScoreData);
        }
    }


}

public class ScoreData
{
    public string id;
    public int mode;
    public int score;
    public int playCount;
}
