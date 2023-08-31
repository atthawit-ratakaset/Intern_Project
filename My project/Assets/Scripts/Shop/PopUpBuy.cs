using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PopUpBuy : MonoBehaviour
{
    public static PopUpBuy instance;

    public GameObject popUpBuy;
    public GameObject popUpComfirm;
    public GameObject popUpFinsh;
    public GameObject alertPopUp;
    public TMP_Text alertText;
    public TMP_Text idName;
    public string IdObject;
    private CurrencyData playerData;
    string types;

    private void Start()
    {
        instance = this;
    }
    public void Buy()
    {

        if (ButtonSkinDisplay.get != null)
        {
            IdObject = ButtonSkinDisplay.get.ID;
            GetIDButtonSkin(IdObject);
           
        }

        if (ShopMusicDisplay.get != null)
        {
            IdObject = ShopMusicDisplay.get.idSong;
            GetIDMusic(IdObject);
        }

        if (ItemDisplay.get == null)
        {

        } else
        {
            if (ItemDisplay.get.types == CurrencytypesItmes.Coin)
            {
                CoinsRefill();
                
                
            }
            else if (ItemDisplay.get.types == CurrencytypesItmes.Stamina)
            {
                EnergyRefill();
                
            }
            else if (ItemDisplay.get.types == CurrencytypesItmes.Diamond)
            {
                DiamondsRefill();
                
            }
        }

        
    }

    public void Cancel()
    {
        ItemDisplay.get = null;
        ButtonSkinDisplay.get = null;
        ShopMusicDisplay.get = null;
        popUpBuy.SetActive(false);
        alertPopUp.SetActive(false);

    }

    void GetIDButtonSkin(string ID)
    {
        IDObject id = new IDObject();
        id.idItem = ID;
        ServerApi.Test(id, (d) => { }, (e) => { });
        if (id.canBuy == false)
        {
            types = "Dimond";
            alertText.text = $"Not enough {types}, want to buy more?";
            alertPopUp.SetActive(true);
        } else if (id.canBuy == true)
        {
            popUpComfirm.SetActive(false);
            FinshBuy();
        }

    }

    void GetIDMusic(string ID)
    {
        IDObject id = new IDObject();
        id.idItem = ID;
        ServerApi.IdMusic(id, (d) => { }, (e) => { });
        if (id.canBuy == false)
        {
            types = "Diamond";
            alertText.text = $"Not enough {types}, want to buy more?";
            alertPopUp.SetActive(true);
        }
        else if (id.canBuy == true)
        {
            popUpComfirm.SetActive(false);
            FinshBuy();
        }

    }
    public void DiamondsRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });

        int currencyDimonds = playerData.diamonds;
        currencyDimonds += ItemDisplay.get.itemValue;

        playerData.SaveDiamonds(currencyDimonds);
        popUpComfirm.SetActive(false);
        FinshBuy();
    }


    public void CoinsRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });

        int currencyDimonds = playerData.diamonds;
        int currencyCoins = playerData.coins;
        if (currencyDimonds >= ItemDisplay.get.price)
        {
            currencyDimonds -= ItemDisplay.get.price;
            playerData.SaveDiamonds(currencyDimonds);

            currencyCoins += ItemDisplay.get.itemValue;
            playerData.SaveCoins(currencyCoins);
            popUpComfirm.SetActive(false);
            FinshBuy();
        } else if (currencyDimonds != ItemDisplay.get.price)
        {   

            types = "Diamond";
            alertText.text = $"Not enough {types}, want to buy more?";
            alertPopUp.SetActive(true);
        }

    }

    public void AlertBuy()
    {
        Cancel();
        Debug.Log(types);
        if (types == "Coin")
        {
            SetObject.instance.CoinMenu();
        }else if (types == "Diamond")
        {
            SetObject.instance.DiaondMenu();
        }else if (types == "Energy")
        {
            SetObject.instance.EnergyMenu();
        }
    }

    public void EnergyRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });
        int currencyDimonds = playerData.diamonds;
        int currencyEnergy = playerData.energy;
        if (currencyDimonds >= ItemDisplay.get.price)
        {
            currencyDimonds -= ItemDisplay.get.price;
            playerData.SaveDiamonds(currencyDimonds);

            currencyEnergy += ItemDisplay.get.itemValue;
            playerData.SaveEnergy(currencyEnergy);
            popUpComfirm.SetActive(false);
            FinshBuy();
        }
        else if (currencyDimonds != ItemDisplay.get.price)
        {
            
            types = "Diamond";
            alertText.text = $"Not enough {types}, want to buy more?";
            alertPopUp.SetActive(true);
        }

    }

    public void FinshBuy()
    {
        popUpComfirm.SetActive(true);
        popUpFinsh.SetActive(true);
        ItemDisplay.get = null;
        ButtonSkinDisplay.get = null;
        ShopMusicDisplay.get = null;
    }

    public void CloseFinshPopUp()
    {
        popUpBuy.SetActive(false);
    }
}
