using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security;

public class GameManager : Singleton<GameManager>
{
 

    [SerializeField]
    PlayerData playerData;

    public float Score => playerData.score;

    void Start()
    {
        // this._level = PlayerPrefs.GetInt("Level");
        // this._score = PlayerPrefs.GetInt("Score");

        ObserverManager.AddListener(ObserverKey.addScore, AddScore);
        ObserverManager.AddListener(ObserverKey.loadPlayerData, loadData);
     
    }

    void OnDestroy()
    {
        ObserverManager.RemoveListener(ObserverKey.addScore, AddScore);
        ObserverManager.RemoveListener(ObserverKey.loadPlayerData, loadData);
    }

    void loadData(params object[] datas)
    {
        this.playerData = (PlayerData)datas[0];
    }


    public void AddScore(params object[] datas)
    {
        this.playerData.score += (float)datas[0];
        if (this.playerData.score >= this.playerData.maxScoreLevelUp)
        {
            this.playerData.level++;
            this.playerData.score = 0;
        }
        ObserverManager.Notify(ObserverKey.savePlayerData, this.playerData);
    }

    public void ResetScore()
    {
        this.playerData.score = 0;
    }
}


[System.Serializable]
public class PlayerData
{
    public int level;
    public float score;

    public int maxScoreLevelUp = 10;
}