using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

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

        onComplete?.Invoke(data);
    }

    public async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyData data = Resources.Load<CurrencyData>("Currency/CurrencyData");

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

        onComplete?.Invoke(data);
    }

    public async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        ThemeData data = Resources.Load<ThemeData>("Storage/Button/ThemeData");

        onComplete?.Invoke(data);
    }

    public async UniTask GetStorageMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        AllMusicData data = Resources.Load<AllMusicData>("Storage/Music/StorageMusic");

        onComplete?.Invoke(data);
    }

    public async UniTask IdMusic(IDObject idObject, UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyData data = Resources.Load<CurrencyData>("Currency/CurrencyData");
        int currencyDimonds = data.diamonds;
        AllMusicData shopMusic = Resources.Load<AllMusicData>("Shop/Music/ShopMusic");
        AllMusicData storageMusic = Resources.Load<AllMusicData>("Storage/Music/StorageMusic");
        AllMusicData selectMusic = Resources.Load<AllMusicData>("Music/MusicData");

        foreach (GetValue value in shopMusic.getMusicData)
        {
            if (value.idSong == idObject.idItem)
            {
                if (currencyDimonds >= value.price)
                {
                    idObject.canBuy = true;
                    currencyDimonds -= value.price;
                    shopMusic.Remove(value);
                    value.alreadyBuy = true;
                    shopMusic.Add(value);
                    shopMusic.Save(shopMusic);
                    data.SaveDiamonds(currencyDimonds);
                    storageMusic.Add(value);
                    storageMusic.Save(storageMusic);
                    MusicShopShow.instance.CheckSkin();

                } else if (currencyDimonds < value.price){
                    idObject.canBuy = false;
                }
            }
        }
    }

    public async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyData data = Resources.Load<CurrencyData>("Currency/CurrencyData");
        int currencyDimonds = data.diamonds;
        ThemeData themeShop = Resources.Load<ThemeData>("Shop/Theme/ButtonSkinData");
        ThemeData storageButtonSkinData = Resources.Load<ThemeData>("Storage/Button/ThemeData");
        foreach (ThemeButtonSkinInfo buttonSkin in themeShop.skinData)
        {
            if (buttonSkin.ID == idObject.idItem)
            {   
                if (currencyDimonds >= buttonSkin.price)
                {
                 
                    currencyDimonds -= buttonSkin.price;
                    themeShop.Remove(buttonSkin);
                    buttonSkin.alreadyBuy = true;
                    themeShop.Add(buttonSkin);
                    themeShop.Save(themeShop);
                    data.SaveDiamonds(currencyDimonds);
                    idObject.canBuy = true;
                    storageButtonSkinData.Add(buttonSkin);
                    storageButtonSkinData.Save(storageButtonSkinData);
                    ThemeShow.instance.CheckSkin();
                } else if (currencyDimonds < buttonSkin.price)
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
