using UnityEngine;

public class ThemeShow : MonoBehaviour
{
    public static ThemeShow instance;
    [Header("Button Skin Item")]
    public ButtonSkinDisplay itemPrefabBthSkin;
    public ThemeBgDisplay itemPrefabBg;

    public string path;
    public GameObject buttonParentBtnSkin;
    public GameObject parentBg;
    public ThemeData getData;
    public GameObject popUpBuy;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        getData = Resources.Load<ThemeData>(path);
        CheckSkin();
    }

    public void CheckSkin()
    {
        DestroyObject(buttonParentBtnSkin);
        DestroyObject(parentBg);
        if (getData.skinData.Count != 0)
        {
            for (int i = 0; i < getData.skinData.Count; i++)
            {
                ButtonSkinDisplay newButton = Instantiate(itemPrefabBthSkin, buttonParentBtnSkin.transform);
                newButton.name = $"Item{i}";
                newButton.info = getData.skinData[i];
                newButton.popUpBuy = popUpBuy;
            }
        }


        if (getData.bgData.Count != 0)
        {
            for (int i = 0; i < getData.bgData.Count; i++)
            {
                ThemeBgDisplay newButton = Instantiate(itemPrefabBg, parentBg.transform);
                newButton.name = $"Item{i}";
                newButton.info = getData.bgData[i];
                newButton.popUpBuy = popUpBuy;
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

}
