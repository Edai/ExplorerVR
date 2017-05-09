using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class AbstractLevelManager : MonoBehaviour
{
    [SerializeField]
    protected string name = "Scene";

    [SerializeField]
    protected uint id = 0;
    public uint ID {
        get
        {
            return id;
        }
    }

    [SerializeField]
    protected Material skybox;

    [SerializeField]
    protected GameObject startPoint;

    [SerializeField]
    protected GameObject endPoint;

    [SerializeField]
    protected GameObject decor;

    [SerializeField]
    protected List<AudioClip> backgroundSounds;

    [SerializeField]
    protected List<GameObject> objectsToActivate;

    protected bool playing = false;

    public void Init()
    {
        Debug.Log("Welcome to " + name + " Level!");
        RenderSettings.skybox = this.skybox;
        GameManager.Instance.CurrentLevelManager = this;
    }

    public void InitSound()
    {
        for (int i = 0; i < this.backgroundSounds.Count; i++)
        {
            SoundManager.Instance.AddSound(this.backgroundSounds[i]);
        }
    }
    public void ShowEnvironment()
    {
        for (int i = 0; i < objectsToActivate.Count; i++)
            objectsToActivate[i].SetActive(true);
    }

    public abstract IEnumerator BeginExperience();

    public void StartExperience()
    {
        if (this.playing == false)
        {
            this.playing = true;
            this.startPoint.active = false;
            this.StartCoroutine(this.BeginExperience());
        }
    }

    public abstract IEnumerator EndExperience(bool loose = false);

    public void StopExperience(bool loose = false)
    {
        if (this.playing == true)
        {
            this.StartCoroutine(this.EndExperience(loose));
            SoundManager.Instance.StopPlaying();
            this.playing = false;
        }
    }

}