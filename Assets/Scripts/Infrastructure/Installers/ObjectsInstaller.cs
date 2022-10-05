using UnityEngine;
using Zenject;

public class ObjectsInstaller : MonoInstaller
{
    //[SerializeField] private FloatingJoystick _floatingJoystick;
    
    public override void InstallBindings()
    {
        
    }

    private void BindJoystick()
    {
        //Container.Bind<FloatingJoystick>().From
    }
    
}
