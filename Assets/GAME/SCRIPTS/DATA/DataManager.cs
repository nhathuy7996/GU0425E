using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Invoke("LoadDataPlayer", 1);
        ObserverManager.AddListener(ObserverKey.savePlayerData, SaveDataPlayer);
    }

    void OnDestroy()
    {
        ObserverManager.AddListener(ObserverKey.savePlayerData, SaveDataPlayer);
    }

    public void LoadDataPlayer()
    {
        string json = PlayerPrefs.GetString(typeof(PlayerData).ToString(), "{}");
        var playerData = JsonUtility.FromJson<PlayerData>(json);
        ObserverManager.Notify(ObserverKey.loadPlayerData, playerData);
    }

    public void SaveDataPlayer(object[] datas)
    {
        PlayerPrefs.SetString(typeof(PlayerData).ToString(), JsonUtility.ToJson((PlayerData)datas[0]));

    }


    public void SaveDataManual()
    {
        Debug.Log("Save Data Manual");
    }
 
}
