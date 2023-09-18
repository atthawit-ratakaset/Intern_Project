using TMPro;
using UnityEngine;

public class DataCurrency : MonoBehaviour
{
    private PlayerData playerData;
    [SerializeField] TMP_Text playerName;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text diamondsText;
    [SerializeField] TMP_Text energyText;

    void Start()
    {
        playerData = ServerApi.Load();
        if (playerName != null)
        {
            playerName.text = playerData.playerName;
        }

    }

    void Update()
    {
        playerData.UpdateCoins(coinsText);
        playerData.UpdateDiamonds(diamondsText);
        playerData.UpdateEnergy(energyText);
    }

}
