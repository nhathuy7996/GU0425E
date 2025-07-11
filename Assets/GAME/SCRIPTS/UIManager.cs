using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text textScore;

    void Start()
    {
        ObserverManager.AddListener(ObserverKey.savePlayerData, UpdateScore);
        ObserverManager.AddListener(ObserverKey.loadPlayerData, UpdateScore);
    }

    void OnDestroy()
    {
        ObserverManager.RemoveListener(ObserverKey.savePlayerData, UpdateScore);
        ObserverManager.RemoveListener(ObserverKey.loadPlayerData, UpdateScore);
    }

    void UpdateScore(params object[] datas)
    {
        var playerData = (PlayerData)datas[0];
        textScore.text = playerData.level.ToString();
    }
}
