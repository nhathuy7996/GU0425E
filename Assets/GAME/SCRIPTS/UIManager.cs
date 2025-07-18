using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text textScore;
    [SerializeField] GameObject popupSetting;
    [SerializeField] Button btnHome, btnReplay;
    [SerializeField] GamePlayScene gamePlayScene;

    void Start()
    {
        ObserverManager.AddListener(ObserverKey.savePlayerData, UpdateScore);
        ObserverManager.AddListener(ObserverKey.loadPlayerData, UpdateScore);

        btnHome.onClick.AddListener(this.gamePlayScene.BackToMenu);
        btnReplay.onClick.AddListener(this.gamePlayScene.reloadGame);
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


    public void OnOffPopUpSetting()
    {
        if (this.popupSetting.activeSelf)
        {
            this.popupSetting.SetActive(false);
            return;
        }

        this.popupSetting.SetActive(true);
        return;
    }

}
