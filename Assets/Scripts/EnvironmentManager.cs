using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnvironmentManager : Singleton<EnvironmentManager> {

    #region FADING
    public RawImage fadeOutUIImage;
    public float fadeSpeed = 0.8f;

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }

    #endregion

    void Start()
    {
        if (GameManager.Instance.LevelNames.Count == 0)
            Debug.LogError("Empty scene list in Environment Manager.");
        this.StartApp();
    }

    public void StartApp()
    {
        this.StartCoroutine(LoadSceneAsync(GameManager.Instance.LevelNames[0]));
    }

    public void ChangeToScene(string sceneName)
    {
        Debug.Log("Change to scene " + sceneName);
        StartCoroutine(ChangeToSceneAsync(sceneName));
    }

    private IEnumerator ChangeToSceneAsync(string sceneName)
    {
        foreach (string s in GameManager.Instance.LevelNames)
        {
            if ((s != null) && (s != sceneName))
            {
                yield return UnloadSceneAsync(s);
            }
        }
        yield return LoadSceneAsync(sceneName);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Scene s = SceneManager.GetSceneByName(sceneName);
        if (s.IsValid() == false)
        {
            AsyncOperation LoadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return Fade(FadeDirection.Out);
            yield return LoadOperation;
        }
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        Scene s = SceneManager.GetSceneByName(sceneName);
        if (s.IsValid())
        {
            AsyncOperation UnloadOperation = SceneManager.UnloadSceneAsync(s);
            yield return Fade(FadeDirection.In);
            yield return UnloadOperation;
        }
    }
}
