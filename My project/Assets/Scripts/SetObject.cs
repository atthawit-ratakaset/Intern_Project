using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetObject : MonoBehaviour
{
    public static SetObject instance;
    

    [Header("SCENCE")]
    public GameObject menuScene;
    public GameObject selectMusicScene;
    public GameObject shopScene;

    [Header("MENU POPUP")]
    public GameObject helpPopUp;

    [Header("PLAY POPUP")]
    public GameObject helpPanel;

    [Header("SHOP MENU")]
    public GameObject special;
    public GameObject theme;
    public GameObject currency;
    public GameObject energyPack;

    [Header("SHOP TEXT")]
    public TMP_Text specialText;
    public TMP_Text themeText;
    public TMP_Text currencyText;
    public TMP_Text energyPackText;

    [Header("THEME")]
    public GameObject button;
    public TMP_Text buttonText;
    public GameObject noteSkin;
    public TMP_Text noteText;
    public GameObject effect;
    public TMP_Text effectText;
    public GameObject themeSet;
    public TMP_Text themeMenuText;

    [Header("CURRENCY")]
    public GameObject coin;
    public TMP_Text coinText;
    public GameObject diamond;
    public TMP_Text diamondText;

    [HideInInspector]
    public int whatScene;

    int test;
    bool menu = true;
    bool play = false;
    bool help = false;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        test = StateScene.menu;
        if (whatScene != test)
        {
            menuScene.SetActive(false);
            selectMusicScene.SetActive(true);
        }
    }

    public void Play()
    {
        menu = false;
        play = true;
        menuScene.SetActive(false);
        selectMusicScene.SetActive(true);
    }

    public void Help()
    {
        if (menu == true)
        {
            if (help == true)
            {
                helpPopUp.SetActive(false);
                help = false;
            }
            else
            {
                help = true;
                helpPopUp.SetActive(true);
            }
        } else if (play == true)
        {
            if (help == true)
            {
                helpPanel.SetActive(false);
                help = false;
            }
            else
            {
                help = true;
                helpPanel.SetActive(true);
            }
        }
        
    }

    public void ReturnLobby()
    {
        play = false;
        menu = true;
        menuScene.SetActive(true);
        selectMusicScene.SetActive(false);
    }

    public void Shop()
    {   
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = Color.white;
        currencyText.color = Color.white;
        energyPackText.color = Color.white;
    }

    public void exitShop()
    {
        shopScene.SetActive(false);
        if (play == true)
        {
            selectMusicScene.SetActive(true);
        } else if (menu == true)
        {
            menuScene.SetActive(true);
        }
        
    }

    public void Speaical()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = Color.white;
        currencyText.color = Color.white;
        energyPackText.color = Color.white;
    }

    public void EnergyMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(true);
        specialText.color = Color.white;
        themeText.color = Color.white;
        currencyText.color = Color.white;
        energyPackText.color = new Color32(253, 6, 83, 255);
    }

    public void CoinMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = Color.white;
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = Color.white;

        coin.SetActive(true);
        diamond.SetActive(false);
        coinText.color = new Color32(253, 6, 83, 255);
        diamondText.color = Color.white;
    }

    public void DiaondMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = Color.white;
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = Color.white;

        coin.SetActive(false);
        diamond.SetActive(true);
        coinText.color = Color.white;
        diamondText.color = new Color32(253, 6, 83, 255);
    }

    public void ThemeMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(true);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = Color.white;
        energyPackText.color = Color.white;
        ButtonMenu();
    }

    public void ButtonMenu()
    {
        button.SetActive(true);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(false);
        noteText.color = Color.white;
        effect.SetActive(false);
        effectText.color = Color.white;
        themeSet.SetActive(false);
        themeMenuText.color = Color.white;
    }

    public void NoteSkinMenu()
    {
        button.SetActive(false);
        buttonText.color = Color.white;
        noteSkin.SetActive(true);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(false);
        effectText.color = Color.white;
        themeSet.SetActive(false);
        themeMenuText.color = Color.white;
    }

    public void EffectMenu()
    {
        button.SetActive(false);
        buttonText.color = Color.white;
        noteSkin.SetActive(false);
        noteText.color = Color.white;
        effect.SetActive(true);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(false);
        themeMenuText.color = Color.white;
    }

    public void SubThemeMenu()
    {
        button.SetActive(false);
        buttonText.color = Color.white;
        noteSkin.SetActive(false);
        noteText.color = Color.white;
        effect.SetActive(false);
        effectText.color = Color.white;
        themeSet.SetActive(true);
        themeMenuText.color = new Color32(253, 6, 83, 255);
    }

}
