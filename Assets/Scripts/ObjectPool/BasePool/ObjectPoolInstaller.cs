using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [Header("Projectile Pool Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private int projectilePoolSize;
    
    [Header("Enemy Pool Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private int enemyPoolSize;
    
    public override void InstallBindings()
    {
        Container.Bind<ProjectilePool>().AsSingle().WithArguments(projectilePrefab,projectileParent,projectilePoolSize).NonLazy();
        Container.Bind<ProjectilePoolEvent>().AsSingle().NonLazy();
        
        Container.Bind<EnemyPool>().AsSingle().WithArguments(enemyPrefab,enemyParent,enemyPoolSize).NonLazy();
        Container.Bind<EnemyPoolEvent>().AsSingle().NonLazy();
    }
}
