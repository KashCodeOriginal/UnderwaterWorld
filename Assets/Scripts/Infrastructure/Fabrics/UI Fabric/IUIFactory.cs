using System.Threading.Tasks;
using UnityEngine;

public interface IUIFactory : IUIInfo
{
    public void CreateLoadingScreen();
    public void DestroyLoadingScreen();
    public void CreateGameStartScreen();
    public void DestroyGameStartScreen();
}
