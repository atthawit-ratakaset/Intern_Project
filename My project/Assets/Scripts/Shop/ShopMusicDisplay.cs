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

    public Image itemImg;
    public Image icon;
    public TMP_Text price;
    public GameObject popUpBuy;

    public void Start()
    {
        instance = this;

        button.onClick.AddListener(delegate () { PopUpToBuy(info); });
        if (info.alreadyBuy == false)
        {
            itemImg.gameObject.GetComponent<Image>().sprite = info.image;
            itemName.text = info.songName;
            icon.gameObject.GetComponent<Image>().sprite = info.currencyType;
            price.text = info.price.ToString();
        }
        else
        {
            theSR.color = Color.black;
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
