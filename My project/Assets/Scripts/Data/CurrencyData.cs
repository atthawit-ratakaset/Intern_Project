using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "My project/CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    public string saveKey;
    public string playerName;
    public int energy;
    public int coins;
    public int diamonds;

    public ThemeButtonSkinInfo playerButtonSkin;

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
        Debug.Log("overwrite data");
    }


    public void Save()
    {
        if (saveKey.Equals(""))
            saveKey = this.name;

        string jsonData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();

    }

    public void SaveEnergy(int num)
    {
        energy = num;
    }

    public void UpdateEnergy(TMP_Text energys)
    {
        energys.text = energy.ToString();
    }

    public void LoadEnergy(int energys)
    {
        energys = energy;
    }

    public void SaveCoins(int num)
    {
        coins = num;
    }
    
    public void UpdateCoins(TMP_Text coin)
    {
        coin.text = coins.ToString();
    }

    public void LoadCoins(int coin)
    {
        coin = coins;
    }

    public void SaveDiamonds(int num)
    {
        diamonds = num;
    }

    public void UpdateDiamonds(TMP_Text diamond)
    {
        diamond.text = diamonds.ToString();
    }

    public void LoadDiamonds(int diamond)
    {
        diamond = diamonds;
    }

    public void SaveButtonSkin(ThemeButtonSkinInfo data)
    {
        playerButtonSkin.equip = false;
        data.equip = true;
        playerButtonSkin = data;
    }


}
