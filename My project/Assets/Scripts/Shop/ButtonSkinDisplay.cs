using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSkinDisplay : MonoBehaviour
{
    public static ButtonSkinDisplay instance;
    public Image theSR;
    public ThemeButtonSkinInfo info;
    public Button button;
    public static ThemeButtonSkinInfo get;
    public TMP_Text itemName;
    public GameObject priceButton, alreadyBuy;

    PlayerData playerData;
    bool buy = false;
    public Image itemImg;
    public Image icon;
    public TMP_Text price;
    public GameObject popUpBuy;

    public void Start()
    {
        instance = this;
        playerData = ServerApi.Load();
        button.onClick.AddListener(delegate () { PopUpToBuy(info); });

        for (int i = 0; i < playerData.storageButtonSkinData.Count; i++)
        {
            if (playerData.storageButtonSkinData[i] == info.ID)
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
            itemImg.gameObject.GetComponent<Image>().sprite = info.itemImg;
            itemName.text = info.itemName;
            icon.gameObject.GetComponent<Image>().sprite = info.currencyIcon;
            price.text = info.price.ToString();
        }
        else
        {
            itemImg.gameObject.GetComponent<Image>().sprite = info.itemImg;
            itemName.text = info.itemName;
            priceButton.SetActive(false);
            alreadyBuy.SetActive(true);
        }

    }

    public void PopUpToBuy(ThemeButtonSkinInfo data)
    {
        SetObject.instance.PopUpComfirm();
        get = data;
        PopUpBuy.instance.idName.text = get.itemName;

    }

}
