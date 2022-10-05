using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScreen : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    public event Action OnPlayButtonClicked;

    private void Start()
    {
        _startGameButton.onClick.AddListener(PlayButtonPressed);
    }

    private void PlayButtonPressed()
    {
        OnPlayButtonClicked?.Invoke();
    }
}
