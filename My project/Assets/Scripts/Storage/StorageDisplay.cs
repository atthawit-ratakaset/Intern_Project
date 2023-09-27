using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageDisplay : MonoBehaviour
{
    public static StorageDisplay instance;
    public ThemeButtonSkinInfo items;
    public static ThemeButtonSkinInfo get;
    public Image image;
    PlayerData playerData;


    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    public GameObject use;
    public GameObject equipped;
    public Button useButton;
    public Button preview;
    public Image previewImg;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataItem(items); });
        preview.onClick.AddListener(delegate () { PreviewItems(); });
        image.gameObject.GetComponent<Image>().sprite = items.itemImg;

    }

    public void SetDataItem(ThemeButtonSkinInfo getValue)
    {
        playerData = ServerApi.Load();
        get = getValue;
        itemName.text = get.itemName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.itemImg;
        itemInfo.text = get.itemDetail;
        if (get.ID == playerData.btnSkinData)
        {
            equipped.SetActive(true);
            use.SetActive(false);
        }
        else
        {
            use.SetActive(true);
            equipped.SetActive(false);
            useButton.onClick.RemoveAllListeners();
            useButton.onClick.AddListener(delegate () { Equip(); });
        }

    }

    public void Equip()
    {
        playerData = ServerApi.Load();
        playerData.btnSkinData = get.ID;
        use.SetActive(false);
        equipped.SetActive(true);
        ServerApi.Save();

    }

    public void PreviewItems()
    {
        previewPopup.SetActive(true);
        previewImg.sprite = get.previewImg;
    }

}
