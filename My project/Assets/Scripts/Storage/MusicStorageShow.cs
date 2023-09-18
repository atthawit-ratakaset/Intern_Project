using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicStorageShow : MonoBehaviour
{
    public static MusicStorageShow instance;
    public MusicStorage buttonPrefab;
    public GameObject buttonParent;
    public AllMusicData getData;

    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    public GameObject play;
    public GameObject pause;
    public Button selectSong;
    public Button playButton;
    public Button pauseButton;
    public AudioSource audioSource;


    void Start()
    {
        instance = this;
    }

    public void CheckMusic()
    {
        ServerApi.GetStorageMusicData((d) => { getData = d; }, (e) => { });
        DestroyObject(buttonParent);
        for (int i = 0; i < getData.getMusicData.Count; i++)
        {
            MusicStorage newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.name = $"Music{i}";
            newButton.items = getData.getMusicData[i];
            newButton.itemName = itemName;
            newButton.itemImg = itemImg;
            newButton.itemInfo = itemInfo;
            newButton.previewPopup = previewPopup;
            newButton.playButton = playButton;
            newButton.audioSource = audioSource;
            newButton.pasueButton = pauseButton;
            newButton.play = play;
            newButton.pasue = pause;
            newButton.selectSong = selectSong;
            if (i == 0)
            {
                newButton.SetDataItem(getData.getMusicData[i]);

            }


        }

    }

    public void DestroyObject(GameObject gameObject)
    {

        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
