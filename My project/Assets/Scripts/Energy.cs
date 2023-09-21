using System;
using System.Collections;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static Energy instance;
    PlayerData playerData;


    public string timeValue;

    public int maxEnergy = 15;
    [HideInInspector]
    public int currentEnergy;

    public int restoreDuration = 300;
    [HideInInspector]
    public DateTime nextEnergyTime;
    [HideInInspector]
    public DateTime lastEnergyTime;
    [HideInInspector]
    public bool isRestoring = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;


    }
    public void EnergyState()
    {
        playerData = ServerApi.Load();
        currentEnergy = playerData.energy;
        if (!PlayerPrefs.HasKey("Playerdata"))
        {

            Load();
            StartCoroutine(RestoreEnergy());
        }
    }

    public void UseEnergy()
    {
        if (currentEnergy >= 1)
        {
            currentEnergy--;

            if (isRestoring == false)
            {
                if (currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
                }

                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            Debug.Log("Don't have Energy!");
        }
    }

    public IEnumerator RestoreEnergy()
    {

        UpdateEnergyTimer();

        isRestoring = true;

        while (currentEnergy < maxEnergy)
        {

            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while (currentDateTime > nextDateTime)
            {
                if (currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    playerData.energy = currentEnergy;
                    currentEnergy = playerData.energy;
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    Debug.Log(timeToAdd);

                    nextDateTime = AddDuration(timeToAdd, restoreDuration);
                    Debug.Log(playerData.energy);
                    Debug.Log("Add energy" + currentEnergy);
                    ServerApi.Save();

                }
                else
                {
                    break;
                }
            }

            if (isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergyTimer();
            Save();
            yield return null;
        }
        //Debug.Log("Energy full");
        isRestoring = false;
    }

    public DateTime AddDuration(DateTime dateTime, int duration)
    {
        return dateTime.AddSeconds(duration);
    }

    public DateTime StringToDate(string datetime)
    {
        if (String.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(datetime);
        }
    }

    public void UpdateEnergyTimer()
    {
        TimeSpan time = nextEnergyTime - DateTime.Now;
        timeValue = String.Format("{0:D2} : {1:D1}", time.Minutes, time.Seconds);

    }


    public void Load()
    {
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
    }

    public void Save()
    {
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
        playerData.SaveEnergy(currentEnergy);
    }

    public void Reset()
    {
        currentEnergy = 10;
        Save();
    }
}
