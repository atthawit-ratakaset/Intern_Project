using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StorageDisplay : MonoBehaviour
{
    public static StorageDisplay instance;
    public ThemeButtonSkinInfo items;
    public static ThemeButtonSkinInfo get;
    public Image image;
    CurrencyData playerButtonSkin;


    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    public GameObject use;
    public GameObject equipped;
    public Button useButton;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataItem(items); });
        image.gameObject.GetComponent<Image>().sprite = items.itemImg;
    }

    public void SetDataItem(ThemeButtonSkinInfo getValue)
    {
        ServerApi.GetPlayerData((d) => { playerButtonSkin = d; }, (e) => { });
        get = getValue;
        itemName.text = get.itemName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.itemImg;
        itemInfo.text = get.itemDetail;
        if (get.itemName == playerButtonSkin.playerButtonSkin.itemName)
        {
            equipped.SetActive(true);
            use.SetActive(false);
        } else
        {
            use.SetActive(true);
            equipped.SetActive(false);
            useButton.onClick.RemoveAllListeners();
            useButton.onClick.AddListener(delegate () { Equip(); });
        }
       
    }

    public void Equip()
    {
        ServerApi.GetPlayerData((d) => { playerButtonSkin = d; }, (e) => { });
        playerButtonSkin.SaveButtonSkin(get);
        use.SetActive(false);
        equipped.SetActive(true);
        Debug.Log(playerButtonSkin.playerButtonSkin.itemName);
    }
}
