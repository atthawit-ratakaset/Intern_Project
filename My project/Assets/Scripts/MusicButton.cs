using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MusicButton : MonoBehaviour
{
    public static MusicButton instance;
    public GetValue musicData;
    public static GetValue get;
    public TMP_Text songName;
    public Image image;
    public Outline outline;
    public TMP_Text highScore;
    public TMP_Text playCounts;
    public GameObject frame;

    PlayerData playerData;
    public static bool buy = false;

    void Start()
    {   
        instance = this;
        playerData = ServerApi.Load();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataMusic(musicData); });
        btn.onClick.AddListener(delegate () { MenuButton.instance.Test(); });

        for (int i = 0; i < playerData.storageMusicData.Count; i++)
        {
            if (playerData.storageMusicData[i] == musicData.idSong)
            {
                buy = true;
                break;
            }
            else
            {
                buy = false;

            }
        }

        if (buy == false)
        {   

            image.gameObject.GetComponent<Image>().sprite = musicData.imageLock;
            songName.text = musicData.songName.ToString();
            Color color = image.color;
            color.a = 0.5f;
            image.color = color;
        }
        else
        {
            image.gameObject.GetComponent<Image>().sprite = musicData.image;
            songName.text = musicData.songName.ToString();
            Color color = image.color;
            color.a = 1f;
            image.color = color;
        }



    }

    public void SetDataMusic(GetValue getValue)
    {   
        get = getValue;
        frame.SetActive(true);
        if (MenuButton.selectMode == 0)
        {

                if (get.highScoreEasy <= 0)
                {
                    highScore.text = "No record";
                }
                else if (get.highScoreEasy > 0)
                {
                    highScore.text = get.highScoreEasy.ToString();
                }

                if (get.playCountEasy <= 0)
                {
                    playCounts.text = "No record";
                }
                else if (get.playCountEasy > 0)
                {
                    playCounts.text = get.playCountEasy.ToString();
                }
            
        } 
        else if (MenuButton.selectMode == 1)
        {


                if (get.highScoreNormal <= 0)
                {
                    highScore.text = "No record";
                }
                else if (get.highScoreNormal > 0)
                {
                    highScore.text = get.highScoreNormal.ToString();
                }

                if (get.playCountNormal <= 0)
                {
                    playCounts.text = "No record";
                }
                else if (get.playCountNormal > 0)
                {
                    playCounts.text = get.playCountNormal.ToString();
                
            }
        } else if (MenuButton.selectMode == 2)
        {

                if (get.highScoreHard <= 0)
                {
                    highScore.text = "No record";
                }
                else if (get.highScoreHard > 0)
                {
                    highScore.text = get.highScoreHard.ToString();
                }

                if (get.playCountHard <= 0)
                {
                    playCounts.text = "No record";
                }
                else if (get.playCountHard > 0)
                {
                    playCounts.text = get.playCountHard.ToString();
                }
            
        }
    }



}
