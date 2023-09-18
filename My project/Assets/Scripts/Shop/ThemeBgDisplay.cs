using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ThemeBgDisplay : MonoBehaviour
{
    public static ThemeBgDisplay instance;
    public Image theSR;
    public ThemeBgInfo info;
    public Button button;
    public static ThemeBgInfo get;
    public TMP_Text itemName;
    public GameObject priceButton, alreadyBuy;

    PlayerData playerData;
    bool buy = false;
    public Image itemImg;
    public Image icon;
    public TMP_Text price;
    public GameObject popUpBuy;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerData = ServerApi.Load();
        button.onClick.AddListener(delegate () { PopUpToBuy(info); });

        for (int i = 0; i < playerData.storageBgSkinData.Count; i++)
        {
            if (playerData.storageBgSkinData[i] == info.ID)
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

    public void PopUpToBuy(ThemeBgInfo data)
    {
        SetObject.instance.PopUpComfirm();
        get = data;
        PopUpBuy.instance.idName.text = get.itemName;

    }
}
