using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = new PlayerData();
        data.playerName = "Huynn";
        data.level = 10;
        data.items = new itemData[3];

        data.items[0] = new itemData();
        data.items[0].name = "mana";
        data.items[0].quantity = 1;

        data.items[1] = new itemData();
        data.items[1].name = "potion";
        data.items[1].quantity = 10;

        data.items[2] = new itemData();
        data.items[2].name = "gun";
        data.items[2].quantity = 1;

        string jsonConverted = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(typeof(PlayerData).ToString(), jsonConverted);

        string s = PlayerPrefs.GetString(typeof(PlayerData).ToString());

        var dataSaved = JsonUtility.FromJson<PlayerData>(s);



        Debug.Log(dataSaved);


    }


}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;

    public itemData[] items;

}

[System.Serializable]
public class itemData
{
    public string name;
    public int quantity;
}
