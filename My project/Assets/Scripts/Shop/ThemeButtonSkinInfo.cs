using UnityEngine;

[CreateAssetMenu(fileName = "ThemeButtonSkinInfo", menuName = "ThemeItemInfo/ThemeButtonSkinInfo", order = 0)]
public class ThemeButtonSkinInfo : ScriptableObject

{
    public string ID;
    public string itemName;
    public Sprite itemImg;
    public Sprite currencyIcon;
    public int price;
    public string itemDetail;

}
