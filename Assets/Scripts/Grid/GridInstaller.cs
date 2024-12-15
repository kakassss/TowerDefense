using UnityEngine;
using Zenject;

public class GridInstaller : MonoInstaller
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector3 originPos;
    
    public override void InstallBindings()
    {
        Container.Bind<CellManager>().AsSingle().WithArguments(width,height,cellSize,originPos).NonLazy();
        Container.Bind<CellPowerManager>().AsSingle().NonLazy();
    }
}
