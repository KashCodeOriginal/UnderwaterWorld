using Zenject;
using UnityEngine;

public class ObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallPlayer();
    }

    private void InstallPlayer()
    {
        Container.BindInterfacesTo<Player>().AsSingle();
    }
}
