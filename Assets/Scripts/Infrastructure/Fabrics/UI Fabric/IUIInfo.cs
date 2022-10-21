using UnityEngine;

public interface IUIInfo
{
    public GameObject LoadingGameScreen { get; }
    public GameObject StartGameScreen { get; }
    public GameObject GameplayScreen { get; }
    public GameObject PlayerDiedScreen { get; }
}
