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

    [SerializeField] Button btnSFX, btnBGM;
    Text textSFX, textBGM;

    void Start()
    {
        ObserverManager.AddListener(ObserverKey.savePlayerData, UpdateScore);
        ObserverManager.AddListener(ObserverKey.loadPlayerData, UpdateScore);

        btnHome.onClick.AddListener(this.gamePlayScene.BackToMenu);
        btnReplay.onClick.AddListener(this.gamePlayScene.reloadGame);

        textSFX = btnSFX.GetComponentInChildren<Text>();
        textBGM = btnBGM.GetComponentInChildren<Text>();

        textSFX.text = PlayerPrefs.GetInt("SFX", 1) == 1 ? "SFX: ON" : "SFX: OFF";
        textBGM.text = PlayerPrefs.GetInt("BGM", 1) == 1 ? "BGM: ON" : "BGM: OFF";

        btnSFX.onClick.AddListener(OnBtnSFXClick);
        btnBGM.onClick.AddListener(OnBtnBGMClick);
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

    public void OnBtnSFXClick()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            PlayerPrefs.SetInt("SFX", 0);
            textSFX.text = "SFX: OFF";
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 1);
            textSFX.text = "SFX: ON";
        }
    }

    public void OnBtnBGMClick()
    {
        if (PlayerPrefs.GetInt("BGM", 1) == 1)
        {
            PlayerPrefs.SetInt("BGM", 0);
            textBGM.text = "BGM: OFF";
            if (SoundManager.Instant.BgmSource.isPlaying)
            {
                SoundManager.Instant.BgmSource.Stop();
            }
        }
        else
        {
            PlayerPrefs.SetInt("BGM", 1);
            textBGM.text = "BGM: ON";
            if (!SoundManager.Instant.BgmSource.isPlaying)
            {
                SoundManager.Instant.BgmSource.Play();
            } 
        }
    }

}
