using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class MenuScene : MonoBehaviour
{
    public void LoadSceneGamePlay(int id)
    {
        LoadingManager.Instant.LoadScene(id);
    }
}
