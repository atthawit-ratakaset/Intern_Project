using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetObject : MonoBehaviour
{
    public static SetObject instance;
    public AudioSource audioSource;

    [Header("Bg")]
    public Image lobbyBg;
    public Image selectSongBg;
    public Image shopBg;
    public Image mailBg;
    public Image loadBg;
    PlayerData playerData;
    ThemeData bg;
    ThemeBgInfo bgInfo;

    [Header("SCENCE")]
    public GameObject menuScene;
    public GameObject selectMusicScene;
    public GameObject shopScene;

    [Header("MENU POPUP")]
    public GameObject mailScene;
    public GameObject helpPopUp;
    public GameObject settingPopUp;
    public GameObject storagePopUp;

    [Header("MENU SCENE")]
    public GameObject proflie;
    public GameObject returnBtn;
    public GameObject update;
    public GameObject flashSale;
    public GameObject buttonUI;
    public GameObject topUI;

    [Header("STORAGE TEXT AND MENU")]
    public TMP_Text buttonStorageText;
    public TMP_Text themeStorageText;
    public TMP_Text musicStorageText;
    public GameObject buttonSkinShow;
    public GameObject musicShow;
    public GameObject bgShow;
    public GameObject buttonStorage;
    public GameObject themeStorage;
    public GameObject musicStorage;

    [Header("Select MUSIC SCENE")]
    public GameObject allBtn;
    public GameObject storageMusicBtn;
    public GameObject allMusic;
    public GameObject storageMusic;
    public Button all;
    public Sprite allClick;
    public Sprite allUnClick;
    public Sprite storageMusicClick;
    public Sprite storageMusicUnClick;


    [Header("PLAY POPUP")]
    public GameObject helpPanel;


    [Header("SHOP MENU")]
    public GameObject special;
    public GameObject music;
    public GameObject theme;
    public GameObject currency;
    public GameObject energyPack;
    public GameObject popUpBuy;
    public GameObject popUpComfirm;
    public GameObject popUpFinsh;

    [Header("SHOP TEXT")]
    public TMP_Text specialText;
    public TMP_Text musicText;
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
    bool storage = false;
    bool help = false;
    bool mail = false;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        GameManager.LoadStoragePlayerData();
        Energy.instance.EnergyState();

        test = StateScene.menu;
        if (whatScene != test)
        {
            menuScene.SetActive(false);
            selectMusicScene.SetActive(true);
            allMusic.SetActive(true);
            storageMusic.SetActive(false);
            mailScene.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            helpPopUp.SetActive(false);
            helpPanel.SetActive(false);
        }
    }

    public void UpdateBg()
    {
        playerData = ServerApi.Load();
        ServerApi.GetStorageButtonSkinData((d) => { bg = d; }, (e) => { });

        for (int i = 0; i < bg.bgData.Count; i++)
        {
            if (bg.bgData[i].ID == playerData.bgSkin)
            {
                bgInfo = bg.bgData[i];
                break;
            }
        }

        lobbyBg.sprite = bgInfo.itemImg;
        selectSongBg.sprite = bgInfo.itemImg;
        shopBg.sprite = bgInfo.itemImg;
        mailBg.sprite = bgInfo.itemImg;
        loadBg.sprite = bgInfo.itemImg;
    }

    public void MailScene()
    {
        mail = true;
        mailScene.SetActive(true);
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
    }

    public void Play()
    {
        menu = false;
        play = true;
        menuScene.SetActive(false);
        selectMusicScene.SetActive(true);
        allMusic.SetActive(true);
        storageMusic.SetActive(false);
        all.onClick.Invoke();
        if (MenuButton.selectMode == 0)
        {
            MenuButton.instance.easyBtn.onClick.Invoke();
        }
        else if (MenuButton.selectMode == 1)
        {
            MenuButton.instance.normalBtn.onClick.Invoke();
        }
        else if (MenuButton.selectMode == 2)
        {
            MenuButton.instance.hardBtn.onClick.Invoke();
        }
    }

    public void AllMusic()
    {
        allMusic.SetActive(true);
        storageMusic.SetActive(false);
        allBtn.GetComponent<Image>().sprite = allClick;
        storageMusicBtn.GetComponent<Image>().sprite = storageMusicUnClick;
        MusicPopUp.instance.CheckMusic();
    }

    public void ShowMusicInStorage()
    {
        allMusic.SetActive(false);
        storageMusic.SetActive(true);
        allBtn.GetComponent<Image>().sprite = allUnClick;
        storageMusicBtn.GetComponent<Image>().sprite = storageMusicClick;
        MusicPopUp.instance.CheckMusicInStorage();
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
        }
        else if (play == true)
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

    public void Storage()
    {
        storage = true;
        storagePopUp.SetActive(true);
        returnBtn.SetActive(true);
        buttonStorageText.color = new Color32(253, 6, 83, 255);
        themeStorageText.color = Color.white;
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(true);
        themeStorage.SetActive(false);
        musicStorage.SetActive(false);
        proflie.SetActive(false);
        update.SetActive(false);
        flashSale.SetActive(false);
        buttonUI.SetActive(false);
        buttonSkinShow.SetActive(true);
        musicShow.SetActive(false);
        bgShow.SetActive(false);
        StorageShow.instance.CheckSkin();




    }
    public void ReturnLobby()
    {
        play = false;
        menu = true;
        MusicButton.get = null;
        if (storage)
        {
            menuScene.SetActive(true);
            StorageMusic();
        }
        else
        {
            menuScene.SetActive(true);
            selectMusicScene.SetActive(false);
            storagePopUp.SetActive(false);
            mailScene.SetActive(false);
        }

    }

    public void exitStorage()
    {
        storage = false;
        menuScene.SetActive(true);
        selectMusicScene.SetActive(false);
        storagePopUp.SetActive(false);
        mailScene.SetActive(false);
        returnBtn.SetActive(false);
        proflie.SetActive(true);
        update.SetActive(true);
        flashSale.SetActive(true);
        buttonUI.SetActive(true);
        topUI.SetActive(true);
        audioSource.clip = null;
    }

    public void exitMail()
    {
        mail = false;
        mailScene.SetActive(false);
        if (play == true)
        {

            selectMusicScene.SetActive(true);

        }
        else if (menu == true)
        {
            menuScene.SetActive(true);
        }
    }

    public void StorageButton()
    {
        buttonSkinShow.SetActive(true);
        musicShow.SetActive(false);
        bgShow.SetActive(false);
        StorageShow.instance.CheckSkin();
        audioSource.clip = null;

        buttonStorageText.color = new Color32(253, 6, 83, 255);
        themeStorageText.color = Color.white;
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(true);
        themeStorage.SetActive(false);
        musicStorage.SetActive(false);
    }

    public void StorageTheme()
    {
        bgShow.SetActive(true);
        buttonSkinShow.SetActive(false);
        musicShow.SetActive(false);
        audioSource.clip = null;
        StorageShow.instance.CheckBgStorage();
        buttonStorageText.color = Color.white;
        themeStorageText.color = new Color32(253, 6, 83, 255);
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(false);
        themeStorage.SetActive(true);
        musicStorage.SetActive(false);
    }

    public void StorageMusic()
    {
        bgShow.SetActive(false);
        buttonSkinShow.SetActive(false);
        musicShow.SetActive(true);
        MusicStorageShow.instance.CheckMusic();


        buttonStorageText.color = Color.white;
        themeStorageText.color = Color.white;
        musicStorageText.color = new Color32(253, 6, 83, 255);
        buttonStorage.SetActive(false);
        themeStorage.SetActive(false);
        musicStorage.SetActive(true);
    }

    public void Setting()
    {
        settingPopUp.SetActive(true);
    }

    public void QuitSetting()
    {
        settingPopUp.SetActive(false);
    }

    public void Shop()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        mailScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        music.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = new Color32(253, 6, 83, 255);
        musicText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);


    }

    public void exitShop()
    {
        shopScene.SetActive(false);
        if (play == true)
        {
            if (mail == true)
            {
                mailScene.SetActive(true);
            }
            else
            {
                selectMusicScene.SetActive(true);
            }

        }
        else if (menu == true)
        {
            if (mail == true)
            {
                mailScene.SetActive(true);
            }
            else
            {
                menuScene.SetActive(true);
            }
        }

    }

    public void Speaical()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        music.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        musicText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);
    }

    public void EnergyMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        mailScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        music.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(true);
        specialText.color = new Color32(253, 6, 83, 255);
        musicText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = Color.white;
    }

    public void CoinMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        mailScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        music.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        musicText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = Color.white;
        energyPackText.color = new Color32(253, 6, 83, 255);

        coin.SetActive(true);
        diamond.SetActive(false);
        coinText.color = Color.white;
        diamondText.color = new Color32(253, 6, 83, 255);
    }

    public void DiaondMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        mailScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        music.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        musicText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = Color.white;
        energyPackText.color = new Color32(253, 6, 83, 255);

        coin.SetActive(false);
        diamond.SetActive(true);
        coinText.color = new Color32(253, 6, 83, 255);
        diamondText.color = Color.white;
    }

    public void ThemeMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        music.SetActive(false);
        theme.SetActive(true);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        musicText.color = new Color32(253, 6, 83, 255);
        themeText.color = Color.white;
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);
        ButtonMenu();
    }

    public void MusicMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        music.SetActive(true);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        musicText.color = Color.white;
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);
    }

    public void ButtonMenu()
    {
        button.SetActive(true);
        buttonText.color = Color.white;
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
        ThemeShow.instance.CheckSkin();
    }

    public void NoteSkinMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(true);
        noteText.color = Color.white;
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
    }

    public void EffectMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(true);
        effectText.color = Color.white;
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
    }

    public void SubThemeMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(true);
        themeMenuText.color = Color.white;
        ThemeShow.instance.CheckSkin();
    }

    public void PopUpComfirm()
    {
        popUpBuy.SetActive(true);
        popUpComfirm.SetActive(true);
        popUpFinsh.SetActive(false);

    }
}

