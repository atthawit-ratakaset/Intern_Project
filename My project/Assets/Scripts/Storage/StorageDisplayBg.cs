using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageDisplayBg : MonoBehaviour
{
    public static StorageDisplayBg instance;
    public ThemeBgInfo items;
    public static ThemeBgInfo get;
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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataItem(items); });
        image.gameObject.GetComponent<Image>().sprite = items.itemImg;
    }

    public void SetDataItem(ThemeBgInfo getValue)
    {
        playerData = ServerApi.Load();
        get = getValue;
        itemName.text = get.itemName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.itemImg;
        itemInfo.text = get.itemDetail;
        if (get.ID == playerData.bgSkin)
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
        playerData.bgSkin = get.ID;
        playerData.btnSkinData = get.idBtn;
        //SetObject.instance.UpdateBg();
        use.SetActive(false);
        equipped.SetActive(true);
        ServerApi.Save();

    }
}
