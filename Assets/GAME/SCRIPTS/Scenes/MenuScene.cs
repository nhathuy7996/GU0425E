using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class MenuScene : MonoBehaviour
{
    public void LoadSceneGamePlay()
    {
        LoadingManager.Instant.LoadScene(1);
    }
}
