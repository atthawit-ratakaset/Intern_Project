using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameObject;
    public static ThemeData buttonSkin;
    public static AllMusicData musicData;
    public static PlayerData playerData;
    
    private void Start()
    {
        ServerApi.InitAquaristaAPI();
        if (instance != null)
        {
            Destroy(gameObject);
        }else
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

        //StorageButtonSkinData
        if (playerData.storageButtonSkinData.Count == 0)
        {
            foreach (ThemeButtonSkinInfo skinInfo in buttonSkin.skinData)
            {
                playerData.storageButtonSkinData.Add(skinInfo.ID);
            }
        }
        else if (playerData.storageButtonSkinData.Count == buttonSkin.skinData.Count)
        {
            Debug.Log("Correct btn skin list");
        } 
        else if (playerData.storageButtonSkinData.Count > buttonSkin.skinData.Count)
        {
            for (int i = 0; i < playerData.storageButtonSkinData.Count; i++)
            {
                for (int a = 0; a < buttonSkin.skinData.Count; a++)
                {
                    if (playerData.storageButtonSkinData[i] == buttonSkin.skinData[a].ID)
                    {
                        x = true;
                        id = null;
                        break;
                    } 
                    else
                    {
                        x = false;
                        id = playerData.storageButtonSkinData[i];
                    }
                }
                if (x == true)
                {
                    Debug.Log(playerData.storageButtonSkinData[i] + " have!");
                } else
                {
                    playerData.storageButtonSkinData.Remove(id);
                    Debug.Log(id + " Don't have. So, Remove from list");
                }
            }
        }
        else
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
                    }
                }
                if (x == true)
                {
                    Debug.Log(buttonSkin.skinData[i].ID + " Already have!");
                }
                else
                {
                    playerData.storageButtonSkinData.Add(id);
                    Debug.Log(id + " Add to list");
                }
            }
        }



        //StorageMusicData
        if (playerData.storageMusicData.Count == 0)
        {
            foreach (GetValue songInfo in musicData.getMusicData)
            {
                playerData.storageMusicData.Add(songInfo.idSong);
            }
        } 
        else if (playerData.storageMusicData.Count == musicData.getMusicData.Count)
        {
            Debug.Log("Correct storage music list");
        }
        else if (playerData.storageMusicData.Count > musicData.getMusicData.Count)
        {

            for (int i = 0; i < playerData.storageMusicData.Count; i++)
            {

                for (int a = 0; a < musicData.getMusicData.Count; a++)
                {
                    if (playerData.storageMusicData[i] == musicData.getMusicData[a].idSong)
                    {
                        x = true;
                        id = null;
                        break;
                    }
                    else
                    {
                        x = false;
                        id = playerData.storageMusicData[i];
                    }
                }
                if (x == true)
                {
                    Debug.Log(playerData.storageMusicData[i] + " have!");
                }
                else
                {
                    playerData.storageMusicData.Remove(id);
                    Debug.Log(id + " Don't have. So, Remove from list");
                }
            }

        }
        else
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
                    } else
                    {
                        x = false;
                        id = musicData.getMusicData[i].idSong;
                    }
                }
                if (x == true)
                {
                    Debug.Log(musicData.getMusicData[i].idSong + " Already have!");
                } else
                {
                    playerData.storageMusicData.Add(id);
                    Debug.Log(id + " Add to list");
                }
            }
        }
        
        ServerApi.Save();
    }

 
}
