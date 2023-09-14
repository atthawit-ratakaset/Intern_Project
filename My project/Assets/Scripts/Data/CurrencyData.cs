using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "My project/CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    public string saveKey;
    public string playerName;
    public int energy;
    public int coins;
    public int diamonds;

    public string btnSkinData;



}
