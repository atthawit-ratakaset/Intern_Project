using UnityEngine;

[CreateAssetMenu(fileName = "ThemeButtonSkinInfo", menuName = "ThemeItemInfo/ThemeBgInfo", order = 0)]
public class ThemeBgInfo : ScriptableObject
{
    public string ID;
    public string itemName;
    public Sprite itemImg;
    public Sprite currencyIcon;
    public int price;
    public string itemDetail;

    [Header("Get Items")]
    public Sprite hpIcon;
    public Sprite hpBar;
    public Sprite hpLine;
    public Sprite bgImg;
    public string idBtn;
    public Sprite perfect;
    public Sprite good;
    public Sprite bad;
    public Sprite miss;
    public Sprite doubleTap1;
    public Sprite doubleTap2;
    public Sprite noteUnlock;
    public Sprite noteLock;
}
