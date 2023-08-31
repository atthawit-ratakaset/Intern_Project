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



    void Start()
    {   
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataMusic(musicData); });
        if (musicData.alreadyBuy == false)
        {
            image.gameObject.GetComponent<Image>().sprite = musicData.imageLock;
            songName.text = musicData.songName.ToString();
        }
        else
        {
            image.gameObject.GetComponent<Image>().sprite = musicData.image;
            songName.text = musicData.songName.ToString();

        }

    }

    public void SetDataMusic(GetValue getValue)
    {   
        get = getValue;
        frame.SetActive(true);
        if (musicData.alreadyBuy == false)
        {
            highScore.text = "No record";
            playCounts.text = "No record";
        }
        else
        {
            if (musicData.highScore <= 0)
            {
                highScore.text = "No record";
            }
            else if (musicData.highScore > 0)
            {
                highScore.text = musicData.highScore.ToString();
            }

            if (musicData.playCount <= 0)
            {
                playCounts.text = "No record";
            }
            else if (musicData.playCount > 0)
            {
                playCounts.text = musicData.playCount.ToString();
            }
        }
    }



}
