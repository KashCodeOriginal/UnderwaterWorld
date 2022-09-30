using System;
using System.Threading.Tasks;

public interface ISceneLoader : ISceneInfoService
{
    public float Progress { get; }
    
    public string LoadingSceneName { get; }

    public Task LoadScene(string sceneName, Action OnComplete);
}
