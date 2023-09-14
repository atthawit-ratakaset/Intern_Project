using System.Collections.Generic;
using TMPro;


public class PlayerData 
{
    public string saveKey = "PlayerData";
    public string playerName;
    public int energy;
    public int coins;
    public int diamonds;

    public List<string> storageButtonSkinData = new List<string>();
    public List<string> storageMusicData = new List<string>();
    public string btnSkinData;

    public  void SaveEnergy(int num)
    {
        energy = num;
    }

    public void SaveCoins(int num)
    {
        coins = num;
    }
    
    public void UpdateEnergy(TMP_Text energys)
    {
        energys.text = $"{energy.ToString()} / {Energy.instance.maxEnergy}";
    }

    public void UpdateCoins(TMP_Text coin)
    {
        coin.text = coins.ToString();
    }


    public void SaveDiamonds(int num)
    {
        diamonds = num;
    }

    public void UpdateDiamonds(TMP_Text diamond)
    {
        diamond.text = diamonds.ToString();
    }




}
