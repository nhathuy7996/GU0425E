using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public void reloadGame()
    {
         
        LoadingManager.Instant.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void BackToMenu()
    {
        LoadingManager.Instant.LoadScene(0);
    }
  
}
