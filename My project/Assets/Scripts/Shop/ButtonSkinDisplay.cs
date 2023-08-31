using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ButtonSkinDisplay : MonoBehaviour
{
    public static ButtonSkinDisplay instance;
    public Image theSR;
    public ThemeButtonSkinInfo info;
    public Button button;
    public static ThemeButtonSkinInfo get;
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
        if(info.alreadyBuy == false)
        {
            itemImg.gameObject.GetComponent<Image>().sprite = info.itemImg;
            itemName.text = info.itemName;
            icon.gameObject.GetComponent<Image>().sprite = info.currencyIcon;
            price.text = info.price.ToString();
        } else
        {
            theSR.color = Color.black;
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
