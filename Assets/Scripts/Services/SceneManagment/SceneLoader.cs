using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    public string CurrentSceneName { get; private set; } = string.Empty;
    public string LoadingSceneName { get; private set; } = string.Empty;
    
    public float Progress { get; private set; }

    public async Task LoadScene(string sceneName, Action OnComplete)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        LoadingSceneName = sceneName;

        while (asyncOperation.isDone == false)
        {
            Progress = asyncOperation.progress;
            await Task.Yield();
        }

        CurrentSceneName = sceneName;
        LoadingSceneName = string.Empty;

        OnComplete?.Invoke();
    }
}
