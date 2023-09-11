using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;

public static class ServerApi 
{
    private static string saveKey = "Playerdata";

    //private static GameServersAPI gameServersAPI;
    private static MockUPGameServerAPI gameServersAPI;
    private const byte autoRetry = 3;

    private static PlayerData playerData;

    private static Dictionary<string, byte> countError = new Dictionary<string, byte>();

    public static PlayerData Load()
    {
        if (playerData == null)
        {
            string data = PlayerPrefs.GetString(saveKey);

            if (!string.IsNullOrEmpty(data))
            {
                playerData = JsonConvert.DeserializeObject<PlayerData>(data);

                return playerData;
            }
            else
            {
                CurrencyData starterData = Resources.Load<CurrencyData>("Currency/PlayerData");
                string[] starter = { "S01", "S02" };
                playerData = new PlayerData();
                playerData.coins = starterData.coins;
                playerData.diamonds = starterData.diamonds;
                playerData.energy = starterData.energy;
                playerData.storageButtonSkinData.Add(starterData.btnSkinData);
                playerData.storageMusicData.AddRange(starter);
                playerData.btnSkinData = starterData.btnSkinData;
                return playerData; 
            }
        }
        else
        {
            return playerData;
        }

    }

    public static void Save()
    {
        string jsonData = JsonConvert.SerializeObject(playerData); //JsonUtility.ToJson(this, true);
        Debug.Log(jsonData);
        PlayerPrefs.SetString(saveKey, jsonData);
    }
    
    

    public static void InitAquaristaAPI()
    {
        InternalAdapter internalAdapter = new InternalAdapter();
        //gameServersAPI = new GameServersAPI(internalAdapter);
        gameServersAPI = new MockUPGameServerAPI(internalAdapter);
    }

    public static async UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetRewards";

        await gameServersAPI.GetRewards((result) =>
        {
            ClearCountAutoRetry(code);
            onComplete?.Invoke(result);

        }, async (error) =>
        {
            await ErrorRequestCall(code, async () => { await GetRewards(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        });
    }

   

    public static async UniTask UnlockReward(UnlockRewardBody request, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"UnlockFeeder";

        await gameServersAPI.UnlockReward(request, (result) =>
        {
            ClearCountAutoRetry(code);
            onComplete?.Invoke(result);

        }, async (error) =>
        {
            await ErrorRequestCall(code, async () => { await UnlockReward(request, onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        });
    }

    private static async UniTask ErrorRequestCall(string method, UnityAction onComplete, UnityAction onFailed)
    {
        //Auto Retry
        if (countError.ContainsKey(method))
        {
            byte counter = countError[method];
            counter++;
            countError[method] = counter;

            if (counter <= autoRetry)
            {
                await UniTask.Delay(3000);
                onComplete?.Invoke();

                return;
            }
        }
        else
        {
            countError.Add(method, 0);

            await UniTask.Delay(3000);
            onComplete?.Invoke();

            return;
        }

        //Reset auto retry.
        countError[method] = 0;

        onFailed?.Invoke();
    }

    public static async UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetCoinData";
        gameServersAPI.GetCoinData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetCoinData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetDiamondData";
        gameServersAPI.GetDiamondData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetDiamondData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetEnergyData";
        gameServersAPI.GetEnergyData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetEnergyData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetShopMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetShopMusicData";
        gameServersAPI.GetShopMusicData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetShopMusicData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetStorageMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetStorageMusicData";
        gameServersAPI.GetStorageMusicData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetStorageMusicData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetMusicData";
        gameServersAPI.GetMusicData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetMusicData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetPlayerData";
        gameServersAPI.GetPlayerData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetPlayerData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetStorageButtonSkinData";
        gameServersAPI.GetStorageButtonSkinData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetStorageButtonSkinData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }
    public static async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"Test";
         gameServersAPI.Test(idObject, (data) =>
          {
              ClearCountAutoRetry(code);
              
              onComplete?.Invoke(data);
          }, async (error) =>
          {
              Debug.Log("error");
              await ErrorRequestCall(code, async () => { await Test(idObject, onComplete, onFailed); }, () =>
              {
                  onFailed?.Invoke(error);

                  Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                  return;
              });
          });

    }

    public static async UniTask IdMusic(IDObject idObject, UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"IdMusic";
        gameServersAPI.IdMusic(idObject, (data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await IdMusic(idObject, onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        });

    }

    //When API callback successed it will remove counter autoretry.
    private static void ClearCountAutoRetry(string code)
    {
        if (countError.ContainsKey(code))
        {
            countError.Remove(code);
        }
    }
}
