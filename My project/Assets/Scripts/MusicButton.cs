using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        btn.onClick.AddListener(delegate () { MenuButton.instance.PlayPopUp(); });

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
            MenuButton.instance.easyBtn.onClick.Invoke();
        }
        else if (MenuButton.selectMode == 1)
        {
            MenuButton.instance.normalBtn.onClick.Invoke();
        }
        else if (MenuButton.selectMode == 2)
        {
            MenuButton.instance.hardBtn.onClick.Invoke();
        }

    }

}
