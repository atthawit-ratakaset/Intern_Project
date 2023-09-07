using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "My project/GetValue", order = 0)]
public class GetValue : ScriptableObject {
    public string idSong;
    public string songName;
    public bool alreadyBuy;
    public Sprite image;
    public Sprite imageLock;
    public AudioClip song;
    public List<NoteData> Easy;
    public List<NoteData> Normal;
    public List<NoteData> Hard;
    public List<NoteData> Event;
    [Header("High Score")]
    public int highScoreEasy;
    public int playCountEasy;
    public int highScoreNormal;
    public int playCountNormal;
    public int highScoreHard;
    public int playCountHard;

    [Header("Setting In Game")]
    public float delay;
    public float timerEasy;
    public float timerNormal;
    public float timerHard;
    public float easySpeed;
    public float normalSpeed;
    public float hardSpeed;
    public float eventSpeed;
    public int targetScore;

    [Header("Shop Setting")]
    public string songInfo;
    public int price;
    public Sprite currencyType;

    public void SaveHighSroce(int num)
    {
        int getMode = MenuButton.selectMode;
        
        if (getMode == 0)
        {  
            if (num > highScoreEasy)
            {
                highScoreEasy = num;
            }
        } else if (getMode == 1)
        {
            if (num > highScoreNormal)
            {
                highScoreNormal = num;
            }
        } else if (getMode == 2)
        {
            if (num > highScoreHard)
            {
                highScoreHard = num;
            }
        }

    }

    public void AddPlayCount()
    {
        int getMode = MenuButton.selectMode;

        if (getMode == 0)
        {
            playCountEasy++;
        }
        else if (getMode == 1)
        {
            playCountNormal++;
        }
        else if (getMode == 2)
        {
            playCountHard++;
        }
    }
}
