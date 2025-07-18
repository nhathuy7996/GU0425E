using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void LoadSceneGamePlay()
    {
        SceneManager.LoadScene(1);
    }
}
