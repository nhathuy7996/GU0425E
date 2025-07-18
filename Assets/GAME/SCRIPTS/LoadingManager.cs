using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    AsyncOperation asyncOperation;

    [SerializeField] Image loadingBar;
    [SerializeField] GameObject loadingPopup;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (this.asyncOperation == null || this.asyncOperation.isDone)
        {
            loadingPopup.SetActive(false);
            return;
        }

        this.loadingBar.fillAmount = this.asyncOperation.progress;
    }

    public void LoadScene(int sceneIndex)
    {
        this.asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPopup.SetActive(true);
    }
}
