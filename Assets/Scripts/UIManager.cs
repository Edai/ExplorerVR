using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Material skybox;

    [SerializeField]
    private List<Button> buttons;

    void Start()
    {
        RenderSettings.skybox = this.skybox;
        for (int i = 0; i < this.buttons.Count; i++)
        {
            switch (i)
            {
                case 0:
                    buttons[i].onClick.AddListener(() => { StartGame();});
                    break;
                case 1:
                    buttons[i].onClick.AddListener(() => { StopGame(); });
                    break;
                default:
                    break;
            }
        }
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    
    public void StopGame()
    {
        GameManager.Instance.StopGame();
    }

}
