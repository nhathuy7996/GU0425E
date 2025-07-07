using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security;

public class GameManager : Singleton<GameManager>
{
 

    [SerializeField]
    PlayerData playerData;

    public int Score => playerData.score;

    void Start()
    {
        // this._level = PlayerPrefs.GetInt("Level");
        // this._score = PlayerPrefs.GetInt("Score");

        string json = PlayerPrefs.GetString(typeof(PlayerData).ToString(), "{}");
        this.playerData = JsonUtility.FromJson<PlayerData>(json); 
    }


    public void AddScore(int scr = 1)
    {
        this.playerData.score += scr;
        if (this.playerData.score >= this.playerData.maxScoreLevelUp)
        {
            this.playerData.level++;
            this.playerData.score = 0;
        }

        PlayerPrefs.SetString(typeof(PlayerData).ToString(), JsonUtility.ToJson(this.playerData));

        // PlayerPrefs.SetInt("Score", this._score);
        // PlayerPrefs.SetInt("Level", this._level);
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
    public int score;

    public int maxScoreLevelUp = 3;
}