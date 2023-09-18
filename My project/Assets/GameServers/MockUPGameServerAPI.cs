using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class MockUPGameServerAPI : IGameServersAdapter
{
    private IInternalAdapter internalAdapter;

    public MockUPGameServerAPI(IInternalAdapter internalAdapter)
    {
        this.internalAdapter = internalAdapter;
    }

    public async UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData coins = Resources.Load<CurrencyItemData>("Shop/Coin/CoinData");

        onComplete?.Invoke(coins);
    }

    public async UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData diamonds = Resources.Load<CurrencyItemData>("Shop/Diamond/DiamondData");

        onComplete?.Invoke(diamonds);
    }

    public async UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData energys = Resources.Load<CurrencyItemData>("Shop/Energy/EnergyData");

        onComplete?.Invoke(energys);
    }

    public async UniTask GetMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        AllMusicData data = Resources.Load<AllMusicData>("Music/MusicData");
        data.Load();


        onComplete?.Invoke(data);
    }

    public async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyData data = Resources.Load<CurrencyData>("Currency/PlayerData");

        onComplete?.Invoke(data);
    }

    public async UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        RewardsData rewardsData = new RewardsData();
        rewardsData.rewards = "mock up GetRewards";

        onComplete?.Invoke(rewardsData);
    }

    public async UniTask GetShopMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        AllMusicData data = Resources.Load<AllMusicData>("Shop/Music/ShopMusic");
        data.Load();
        onComplete?.Invoke(data);
    }

    public async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        ThemeData data = Resources.Load<ThemeData>("Storage/Button/ThemeData");
        data.Load();
        onComplete?.Invoke(data);
    }

    public async UniTask GetStorageMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        AllMusicData data = Resources.Load<AllMusicData>("Storage/Music/StorageMusic");
        data.Load();
        onComplete?.Invoke(data);
    }

    public async UniTask IdBg(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        PlayerData data = ServerApi.Load();
        int currencyDimonds = data.diamonds;
        ThemeData themeShop = Resources.Load<ThemeData>("Shop/Theme/ThemeData");
        ThemeData storageBgData = Resources.Load<ThemeData>("Storage/Button/ThemeData");
        foreach (ThemeBgInfo bg in themeShop.bgData)
        {
            if (bg.ID == idObject.idItem)
            {
                if (currencyDimonds >= bg.price)
                {

                    currencyDimonds -= bg.price;
                    themeShop.RemoveBgSkin(bg);
                    data.storageBgSkinData.Add(idObject.idItem);
                    themeShop.AddBgSkin(bg);
                    themeShop.Save(themeShop);
                    data.SaveDiamonds(currencyDimonds);
                    idObject.canBuy = true;
                    storageBgData.AddBgSkin(bg);
                    storageBgData.Save(storageBgData);
                    data.storageButtonSkinData.Add(bg.idBtn);
                    themeShop.Save();
                    ServerApi.Save();
                    storageBgData.Save();
                    foreach (ThemeButtonSkinInfo btn in themeShop.skinData)
                    {
                        for (int i = 0; i < data.storageButtonSkinData.Count; i++)
                        {
                            if (btn.ID == data.storageButtonSkinData[i])
                            {
                                storageBgData.AddBtnSkin(btn);
                                storageBgData.Save();
                                ServerApi.Save();
                                break;
                            }
                        }

                    }
                    ThemeShow.instance.CheckSkin();
                }
                else if (currencyDimonds < bg.price)
                {
                    idObject.canBuy = false;
                }

            }

        }

        onComplete?.Invoke(storageBgData);


    }

    public async UniTask IdMusic(IDObject idObject, UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        PlayerData data = ServerApi.Load();
        int currencyDimonds = data.diamonds;
        AllMusicData shopMusic = Resources.Load<AllMusicData>("Shop/Music/ShopMusic");
        AllMusicData storageMusic = Resources.Load<AllMusicData>("Storage/Music/StorageMusic");


        foreach (GetValue value in shopMusic.getMusicData)
        {
            if (value.idSong == idObject.idItem)
            {
                if (currencyDimonds >= value.price)
                {
                    idObject.canBuy = true;
                    currencyDimonds -= value.price;
                    shopMusic.Remove(value);
                    data.storageMusicData.Add(idObject.idItem);
                    shopMusic.Add(value);
                    shopMusic.Save(shopMusic);
                    data.SaveDiamonds(currencyDimonds);
                    storageMusic.Add(value);
                    storageMusic.Save(storageMusic);

                    shopMusic.Save();
                    storageMusic.Save();
                    ServerApi.Save();
                    MusicShopShow.instance.CheckSkin();

                }
                else if (currencyDimonds < value.price)
                {
                    idObject.canBuy = false;
                }
            }
        }
    }

    public async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        PlayerData data = ServerApi.Load();
        int currencyDimonds = data.diamonds;
        ThemeData themeShop = Resources.Load<ThemeData>("Shop/Theme/ThemeData");
        ThemeData storageButtonSkinData = Resources.Load<ThemeData>("Storage/Button/ThemeData");
        foreach (ThemeButtonSkinInfo buttonSkin in themeShop.skinData)
        {
            if (buttonSkin.ID == idObject.idItem)
            {
                if (currencyDimonds >= buttonSkin.price)
                {

                    currencyDimonds -= buttonSkin.price;
                    themeShop.RemoveBtnSkin(buttonSkin);
                    data.storageButtonSkinData.Add(idObject.idItem);
                    themeShop.AddBtnSkin(buttonSkin);
                    themeShop.Save(themeShop);
                    data.SaveDiamonds(currencyDimonds);
                    idObject.canBuy = true;
                    storageButtonSkinData.AddBtnSkin(buttonSkin);
                    storageButtonSkinData.Save(storageButtonSkinData);

                    themeShop.Save();

                    ServerApi.Save();
                    storageButtonSkinData.Save();
                    ThemeShow.instance.CheckSkin();
                }
                else if (currencyDimonds < buttonSkin.price)
                {
                    idObject.canBuy = false;
                }

            }

        }

        onComplete?.Invoke(storageButtonSkinData);

    }

    public async UniTask UnlockReward(UnlockRewardBody unlockRewardBody, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        UnlockReward rewardsData = new UnlockReward();
        rewardsData.unlockReward = "mock up UnlockReward";

        onComplete?.Invoke(rewardsData);
    }
}
