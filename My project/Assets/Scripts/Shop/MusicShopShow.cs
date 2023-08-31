using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShopShow : MonoBehaviour
{
    public static MusicShopShow instance;
    [Header("Button Skin Item")]
    public ShopMusicDisplay itemPrefab;

    public GameObject buttonParent;
    public AllMusicData getData;
    public GameObject popUpBuy;
    int currentItem;

    void Start()
    {
        instance = this;
        ServerApi.GetShopMusicData((d) => { getData = d; }, (e) => { });
        currentItem = getData.getMusicData.Count;
        CheckSkin();
    }

    public void CheckSkin()
    {
        DestroyObject(buttonParent);
        if (getData.getMusicData.Count != 0)
        {
            for (int i = 0; i < getData.getMusicData.Count; i++)
            {
                ShopMusicDisplay newButton = Instantiate(itemPrefab, buttonParent.transform);
                newButton.name = $"Item{i}";
                newButton.info = getData.getMusicData[i];
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
