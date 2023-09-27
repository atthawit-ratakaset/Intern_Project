using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageShow : MonoBehaviour
{
    public static StorageShow instance;
    public StorageDisplay buttonPrefab;
    public StorageDisplayBg bgPrefab;
    public string path;
    public GameObject buttonParent;
    public GameObject bgParent;
    ThemeData getData;
    public int itemCount;

    public Image popUpPreview;

    [Header("PopUp Button Skin")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    public GameObject use;
    public GameObject equipped;
    public Button useButton;
    public Button previewBtn;

    [Header("PopUp Bg Skin")]
    public TMP_Text itemNameBg;
    public Image itemImgBg;
    public TMP_Text itemInfoBg;
    public GameObject previewPopupBg;
    public GameObject useBg;
    public GameObject equippedBg;
    public Button useButtonBg;
    public Button previewBg;

    void Start()
    {
        instance = this;

    }

    public void CheckSkin()
    {

        ServerApi.GetStorageButtonSkinData((d) => { getData = d; }, (e) => { });
        DestroyObject(buttonParent);
        DestroyObject(bgParent);
        for (int i = 0; i < getData.skinData.Count; i++)
        {
            StorageDisplay newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.name = $"Music{i}";
            newButton.items = getData.skinData[i];
            newButton.itemName = itemName;
            newButton.itemImg = itemImg;
            newButton.itemInfo = itemInfo;
            newButton.previewPopup = previewPopup;
            newButton.use = use;
            newButton.equipped = equipped;
            newButton.useButton = useButton;
            newButton.preview = previewBtn;
            newButton.previewImg = popUpPreview;

            if (i == 0)
            {
                newButton.SetDataItem(getData.skinData[i]);

            }


        }

    }

    public void CheckBgStorage()
    {
        ServerApi.GetStorageButtonSkinData((d) => { getData = d; }, (e) => { });
        DestroyObject(bgParent);
        for (int i = 0; i < getData.bgData.Count; i++)
        {
            StorageDisplayBg newButton = Instantiate(bgPrefab, bgParent.transform);
            newButton.name = $"Music{i}";
            newButton.items = getData.bgData[i];
            newButton.itemName = itemNameBg;
            newButton.itemImg = itemImgBg;
            newButton.itemInfo = itemInfoBg;
            newButton.previewPopup = previewPopupBg;
            newButton.use = useBg;
            newButton.equipped = equippedBg;
            newButton.useButton = useButtonBg;
            newButton.preview = previewBg;
            newButton.previewImg = popUpPreview;

            if (i == 0)
            {
                newButton.SetDataItem(getData.bgData[i]);

            }


        }
    }

    public void DestroyObject(GameObject gameObject)
    {

        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void ClosePreview()
    {
        previewPopup.SetActive(false);
        previewPopupBg.SetActive(false);
    }
}
