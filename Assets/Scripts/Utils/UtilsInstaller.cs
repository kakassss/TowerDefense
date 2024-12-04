using UnityEngine;
using Zenject;

public class UtilsInstaller : MonoInstaller
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;
    
    public override void InstallBindings()
    {
        Container.Bind<Utils>().AsSingle().WithArguments(camera,layerMask).NonLazy();
        Container.Bind<QuaternionUtils>().AsSingle().NonLazy();
    }
}