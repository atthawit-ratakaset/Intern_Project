using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicStorage : MonoBehaviour
{
    public static MusicStorage instance;
    public GetValue items;
    public static GetValue get;
    public Image image;
    public TMP_Text songName;
    AudioClip clip;
    public int songNum;

    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    public GameObject play;
    public GameObject pasue;
    public Button selectSong;
    public Button playButton;
    public Button pasueButton;
    public AudioSource audioSource;

    void Start()
    {
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataItem(items); });
        image.gameObject.GetComponent<Image>().sprite = items.image;
        songName.text = items.songName.ToString();
    }

    public void SetDataItem(GetValue getValue)
    {
        get = getValue;
        clip = get.song;
        play.SetActive(true);
        pasue.SetActive(false);
        itemName.text = get.songName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.image;
        itemInfo.text = get.songInfo;
        playButton.onClick.RemoveAllListeners();
        pasueButton.onClick.RemoveAllListeners();
        selectSong.onClick.AddListener(delegate () { Play(); });
        playButton.onClick.AddListener(delegate () { PlayTestMusic(); });
        pasueButton.onClick.AddListener(delegate () { Pause(); });
    }

    public void PlayTestMusic()
    {
        play.SetActive(false);
        pasue.SetActive(true);
        audioSource.clip = clip;
        audioSource.Play();

    }

    public void Pause()
    {
        audioSource.Pause();
        pasue.SetActive(false);
        play.SetActive(true);
    }

    public void Play()
    {
        songNum = 2;
        SetObject.instance.Play();
    }
}
