using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
 
    [SerializeField]
    PlayerData playerData;
    [SerializeField] Button btnAddScore;

    public float Score => playerData.score;
    [SerializeField] UnityEvent testEvent;

    void Start()
    {
        // this._level = PlayerPrefs.GetInt("Level");
        // this._score = PlayerPrefs.GetInt("Score");

        ObserverManager.AddListener(ObserverKey.addScore, AddScore);
        ObserverManager.AddListener(ObserverKey.loadPlayerData, loadData);
        btnAddScore.onClick.RemoveAllListeners();

        btnAddScore.onClick.AddListener(ResetScore);
    

        // LoadDataPlayer();
        // ObserverManager.AddListener(ObserverKey.savePlayerData, SaveDataPlayer);
        // ObserverManager.AddListener(ObserverKey.loadPlayerData, LoadDataPlayer);
        // DontDestroyOnLoad(this.gameObject);s
    }

    void OnDestroy()
    {
        ObserverManager.RemoveListener(ObserverKey.addScore, AddScore);
        ObserverManager.RemoveListener(ObserverKey.loadPlayerData, loadData);

         btnAddScore.onClick.RemoveAllListeners();
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