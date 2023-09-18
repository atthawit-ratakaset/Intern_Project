using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public static ItemDisplay instance;
    public CurrencyItemInfo info;
    public Button button;
    public static CurrencyItemInfo get;
    public TMP_Text itemName;
    public TMP_Text itemValue;
    public Image itemImg;
    public Image icon;
    public TMP_Text price;
    public GameObject popUpBuy;
    public TMP_Text timeLimit;

    public void Start()
    {
        instance = this;

        if (info.types == CurrencytypesItmes.DailyCoin || info.types == CurrencytypesItmes.DailyDiamond ||
               info.types == CurrencytypesItmes.DailyStamina)
        {
            timeLimit.text = info.timelimit.ToString() + "H";
            itemName.text = info.itemName;
            itemValue.text = info.itemValue.ToString();
            itemImg.gameObject.GetComponent<Image>().sprite = info.itemImg;
        }
        else if (info.types == CurrencytypesItmes.Coin || info.types == CurrencytypesItmes.Diamond ||
             info.types == CurrencytypesItmes.Stamina)
        {
            button.onClick.AddListener(delegate () { PopUpToBuy(info); });
            itemImg.gameObject.GetComponent<Image>().sprite = info.itemImg;
            itemName.text = info.itemName;
            itemValue.text = info.itemValue.ToString();
            icon.gameObject.GetComponent<Image>().sprite = info.currencyIcon;
            price.text = info.price.ToString();
        }

    }

    public void PopUpToBuy(CurrencyItemInfo data)
    {
        SetObject.instance.PopUpComfirm();
        get = data;
        PopUpBuy.instance.idName.text = get.itemName;

    }


}
