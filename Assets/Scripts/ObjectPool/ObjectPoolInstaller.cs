using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private int projectilePoolSize;
    
    public override void InstallBindings()
    {
        Container.Bind<ProjectilePool>().AsSingle().WithArguments(projectilePrefab,projectileParent,projectilePoolSize).NonLazy();
    }
}
