using TMPro;
using UnityEngine;

public class MusicPopUp : MonoBehaviour
{
    public static MusicPopUp instance;
    public MusicButton buttonPrefab;
    public GameObject buttonParent;
    public GameObject buttonParent2;
    public AllMusicData getValue;
    public TMP_Text highScore;
    public TMP_Text playCounts;
    int test;
    void Start()
    {

        instance = this;
        test = StateScene.menu;
        if (test != 0)
        {
            CheckMusic();
        }
        else
        {
            CheckMusic();
        }

    }

    public void CheckMusic()
    {
        ServerApi.GetMusicData((d) => { getValue = d; }, (e) => { });
        DestroyObject(buttonParent);
        for (int i = 0; i < getValue.getMusicData.Count; i++)
        {

            MusicButton newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.name = $"Music{i}";
            newButton.musicData = getValue.getMusicData[i];
            newButton.highScore = highScore;
            newButton.playCounts = playCounts;

            if (i == 0)
            {
                newButton.SetDataMusic(getValue.getMusicData[i]);
            }

        }
    }

    public void CheckMusicInStorage()
    {
        ServerApi.GetStorageMusicData((d) => { getValue = d; }, (e) => { });
        DestroyObject(buttonParent2);
        for (int i = 0; i < getValue.getMusicData.Count; i++)
        {

            MusicButton newButton = Instantiate(buttonPrefab, buttonParent2.transform);
            newButton.name = $"Music{i}";
            newButton.musicData = getValue.getMusicData[i];
            newButton.highScore = highScore;
            newButton.playCounts = playCounts;

            if (i == 0)
            {
                newButton.SetDataMusic(getValue.getMusicData[i]);
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
