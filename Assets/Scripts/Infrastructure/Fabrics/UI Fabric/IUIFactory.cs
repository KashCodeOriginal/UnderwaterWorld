using UnityEngine;
using System.Threading.Tasks;

public interface IUIFactory : IUIInfo
{
    public void CreateLoadingScreen();
    public void DestroyLoadingScreen();
    public Task<GameObject> CreateGameStartScreen();
    public void DestroyGameStartScreen();
    public Task<GameObject> CreateGameplayScreen();
    public void DestroyGameplayScreen();
}
