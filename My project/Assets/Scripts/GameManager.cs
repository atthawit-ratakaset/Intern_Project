using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameObject;
    public static ThemeData buttonSkin;
    public static ThemeData btnShop;
    public static AllMusicData musicData;
    public static PlayerData playerData;


    private void Start()
    {
        ServerApi.InitAquaristaAPI();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

    }

    public static void LoadStoragePlayerData()
    {
        playerData = ServerApi.Load();
        ServerApi.GetStorageButtonSkinData((d) => { buttonSkin = d; }, (e) => { });
        ServerApi.GetStorageMusicData((d) => { musicData = d; }, (e) => { });

        bool x = false;
        string id = "";

        ThemeBgInfo bgInfo = null;
        ThemeButtonSkinInfo btnInfo = null;
        GetValue musicInfo = null;


        //StorageButtonSkinData
        if (playerData.storageButtonSkinData.Count == buttonSkin.skinData.Count)
        {
            //Debug.Log("Correct btn skin list");
        }
        else if (playerData.storageButtonSkinData.Count > buttonSkin.skinData.Count || playerData.storageButtonSkinData.Count < buttonSkin.skinData.Count)
        {
            for (int i = 0; i < buttonSkin.skinData.Count; i++)
            {
                for (int a = 0; a < playerData.storageButtonSkinData.Count; a++)
                {
                    if (buttonSkin.skinData[i].ID == playerData.storageButtonSkinData[a])
                    {
                        x = true;
                        id = null;
                        break;
                    }
                    else
                    {
                        x = false;
                        id = buttonSkin.skinData[i].ID;
                        btnInfo = buttonSkin.skinData[i];
                    }
                }
                if (x == true)
                {
                    Debug.Log(buttonSkin.skinData[i].ID + " Already have!");
                }
                else
                {
                    playerData.storageButtonSkinData.Remove(id);
                    buttonSkin.RemoveBtnSkin(btnInfo);
                    buttonSkin.Save();
                }
            }
        }


        //StorageBgData
        if (playerData.storageBgSkinData.Count == buttonSkin.bgData.Count)
        {
            //Debug.Log("Correct bg list");
        }
        else if (playerData.storageBgSkinData.Count > buttonSkin.bgData.Count || playerData.storageBgSkinData.Count < buttonSkin.bgData.Count)
        {
            for (int i = 0; i < buttonSkin.bgData.Count; i++)
            {
                for (int a = 0; a < playerData.storageBgSkinData.Count; a++)
                {
                    if (buttonSkin.bgData[i].ID == playerData.storageBgSkinData[a])
                    {
                        x = true;
                        id = null;
                        break;
                    }
                    else
                    {
                        x = false;
                        id = buttonSkin.bgData[i].ID;
                        bgInfo = buttonSkin.bgData[i];
                    }
                }
                if (x == true)
                {
                    Debug.Log(buttonSkin.bgData[i].ID + " Already have!");
                }
                else
                {
                    playerData.storageBgSkinData.Remove(id);
                    buttonSkin.RemoveBgSkin(bgInfo);
                    buttonSkin.Save();
                }
            }
        }
        

        //StorageMusicData
        if (playerData.storageMusicData.Count == musicData.getMusicData.Count)
        {
            //Debug.Log("Correct storage music list");
        }
        else if (playerData.storageMusicData.Count > musicData.getMusicData.Count || playerData.storageMusicData.Count < musicData.getMusicData.Count)
        {

            for (int i = 0; i < musicData.getMusicData.Count; i++)
            {

                for (int a = 0; a < playerData.storageMusicData.Count; a++)
                {
                    if (musicData.getMusicData[i].idSong == playerData.storageMusicData[a])
                    {
                        x = true;
                        id = null;
                        break;
                    }
                    else
                    {
                        x = false;
                        id = musicData.getMusicData[i].idSong;
                        musicInfo = musicData.getMusicData[i];
                    }
                }
                if (x == true)
                {
                    Debug.Log(musicData.getMusicData[i].idSong + " Already have!");
                }
                else
                {
                    playerData.storageMusicData.Remove(id);
                    musicData.Remove(musicInfo);
                    musicData.Save();

                }
            }

        }
        

        ServerApi.Save();
    }



}
