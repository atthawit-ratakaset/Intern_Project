using UnityEngine;


[CreateAssetMenu(fileName = "StorageData", menuName = "My project/StorageData", order = 0)]
public class StorageData : ScriptableObject
{
    public string saveKey;
    public StorageItems[] storageData;
    public void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
        Debug.Log("overwrite data");
    }


    public void Save()
    {
        if (saveKey.Equals(""))
            saveKey = this.name;

        string jsonData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();

    }

}
