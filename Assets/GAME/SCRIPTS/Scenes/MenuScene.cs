using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    [SerializeField] Transform btnManager;
    List<Button> buttons = new List<Button>();

    void Start()
    {
        // for (int i = 0; i < btnManager.childCount; i++)
        // {
        //     Button btn = btnManager.GetChild(i).GetComponent<Button>();
        //     if (btn != null)
        //     {
        //         buttons.Add(btn);
        //         // int id = i;
        //         // btn.onClick.AddListener(() => LoadSceneGamePlay(id));
        //     }

        // }

        this.buttons = this.btnManager.GetComponentsInChildren<Button>().ToList();
        foreach (Button btn in this.buttons)
        {
            int id = this.buttons.IndexOf(btn);
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => LoadSceneGamePlay(id+1));
        }
    }

    public void AddNewButton()
    {
        if (this.buttons.Count() == 0)
        {
            return;
        }

        Button newButton = Instantiate(this.buttons[0], this.btnManager); 
        this.buttons.Add(newButton);
        newButton.onClick.RemoveAllListeners();
        newButton.onClick.AddListener(() => LoadSceneGamePlay(this.buttons.Count()));

    }

    public void LoadSceneGamePlay(int id)
    {
        LoadingManager.Instant.LoadScene(id);
    }
}
