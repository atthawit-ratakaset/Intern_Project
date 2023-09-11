using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class DataCurrency : MonoBehaviour
{
    private PlayerData playerData;

    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text diamondsText;
    [SerializeField] TMP_Text energyText;
    void Start()
    {
        playerData = ServerApi.Load();
    }

    void Update()
    {
        playerData.UpdateCoins(coinsText);
        playerData.UpdateDiamonds(diamondsText);
        playerData.UpdateEnergy(energyText);
    }

}
