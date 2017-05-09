using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class GameManager : Singleton<GameManager>
{
    public List<string> LevelNames;

    private AbstractLevelManager levelManager;
    
    public AbstractLevelManager CurrentLevelManager {
        get
        {
            return this.levelManager;
        }
        set
        {
            this.levelManager = value;
        }
    }

    public void ChangeNextEnvironment(bool loose = false)
    {
        string nextLevel;
        int currentLevel;

        currentLevel = (int)CurrentLevelManager.ID + 1;
        if (loose == true || currentLevel >= this.LevelNames.Count)
            nextLevel = "MainMenu";
        else
            nextLevel = this.LevelNames[currentLevel];
        EnvironmentManager.Instance.ChangeToScene(nextLevel);
    }

    public void StartGame()
    {
        if (this.LevelNames.Count >= 2)
            EnvironmentManager.Instance.ChangeToScene(LevelNames[1]);
        else
            Debug.LogError("No Scene found.");
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
