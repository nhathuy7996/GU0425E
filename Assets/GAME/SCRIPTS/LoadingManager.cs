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
    [SerializeField] Animation blackFade;

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
        //if(Input.GetKeyDown(KeyCode.KeypadEnter))
        //    this.asyncOperation.allowSceneActivation = true;
    }

    public void LoadScene(int sceneIndex)
    {
        this.asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
      //  this.asyncOperation.allowSceneActivation = false;
        loadingPopup.SetActive(true);
        StartCoroutine(waitLoadingDone());
    }

    IEnumerator waitLoadingDone()
    {
        yield return new WaitUntil(()=> this.asyncOperation.isDone);
        this.blackFade.Play();
    }
}
