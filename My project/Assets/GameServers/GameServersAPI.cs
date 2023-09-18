using Cysharp.Threading.Tasks;
using UnityEngine.Events;

public class GameServersAPI : IGameServersAdapter
{
    private IInternalAdapter internalAdapter;

    public GameServersAPI(IInternalAdapter internalAdapter)
    {
        this.internalAdapter = internalAdapter;
    }

    public async UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string url = string.Format($"api path");

        RewardsData rewardAll = await internalAdapter.Get<RewardsData>(url);

        if (rewardAll.apiCheckRequest != null)
        {
            onFailed?.Invoke(rewardAll.apiCheckRequest);
            return;
        }

        onComplete?.Invoke(rewardAll);
    }

    public async UniTask GetShopMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public UniTask GetStorageMusicData(UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask IdBg(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask IdMusic(IDObject idObject, UnityAction<AllMusicData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        throw new System.NotImplementedException();
    }

    public async UniTask UnlockReward(UnlockRewardBody unlockRewardBody, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        UnlockReward unlockReward = await internalAdapter.Post<UnlockReward, UnlockRewardBody>($"api path", unlockRewardBody);

        if (unlockReward.apiCheckRequest != null)
        {
            onFailed?.Invoke(unlockReward.apiCheckRequest);
            return;
        }

        onComplete?.Invoke(unlockReward);
    }
}
