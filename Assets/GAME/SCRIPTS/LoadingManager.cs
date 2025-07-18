using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    AsyncOperation asyncOperation;

    [SerializeField] Slider loadingBar;
    [SerializeField] GameObject loadingPopup;
    [SerializeField] Animation blackFade;
    [SerializeField] List<AnimationClip> fadeClips = new List<AnimationClip> ();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);

        this.loadingBar.onValueChanged.AddListener((value) =>
        {
            Debug.LogError(value);
        });
    }
    private void Update()
    {
        if (this.asyncOperation == null || this.asyncOperation.isDone)
        {
            loadingPopup.SetActive(false);
            return;
        }

        this.loadingBar.value = this.asyncOperation.progress;
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
        this.blackFade.clip = this.fadeClips[Random.Range(0, this.fadeClips.Count)];
        this.blackFade.Play();
    }
}
