using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "My project/CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    public string saveKey;
    public string playerName;
    public int energy;
    public int coins;
    public int diamonds;

    public string btnSkinData;
    public string bgSkin;


}
