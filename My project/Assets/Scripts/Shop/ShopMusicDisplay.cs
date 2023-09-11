using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopMusicDisplay : MonoBehaviour
{
    public static ShopMusicDisplay instance;
    public Image theSR;
    public GetValue info;
    public Button button;
    public static GetValue get;
    public TMP_Text itemName;
    public GameObject priceButton, alreadyBuy;
    PlayerData playerData;
    bool buy;


    public Image itemImg;
    public Image icon;
    public TMP_Text price;
    public GameObject popUpBuy;

    public void Start()
    {
        instance = this;
        playerData = ServerApi.Load();
        button.onClick.AddListener(delegate () { PopUpToBuy(info); });

        for (int i = 0; i < playerData.storageMusicData.Count; i++)
        {
            if (playerData.storageMusicData[i] == info.idSong)
            {
                buy = true;
                break;
            }
            else
            {
                buy = false;

            }
        }

        if (buy == false)
        {
            itemImg.gameObject.GetComponent<Image>().sprite = info.image;
            itemName.text = info.songName;
            icon.gameObject.GetComponent<Image>().sprite = info.currencyType;
            price.text = info.price.ToString();
        }
        else
        {
            itemImg.gameObject.GetComponent<Image>().sprite = info.image;
            itemName.text = info.songName;
            priceButton.SetActive(false);
            alreadyBuy.SetActive(true);
        }

    }

    public void PopUpToBuy(GetValue data)
    {
        SetObject.instance.PopUpComfirm();
        get = data;
        PopUpBuy.instance.idName.text = get.songName;

    }
}
