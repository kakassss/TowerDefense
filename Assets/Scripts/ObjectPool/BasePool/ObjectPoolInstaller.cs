using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [Header("Projectile Pool Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private int projectilePoolSize;
    
    [Header("Multiple Enemy Pool Settings")]
    [SerializeField] private List<BaseEnemy> enemiesPrefab;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private List<int> poolsSizes;
    private List<int> poolSizeIndexes;
    
    public override void InstallBindings()
    {
        BindProjectilePool();
        BindEnemyPool();
    }

    private void BindEnemyPool()
    {
        SetPoolSizesIndexes();
        Container.Bind<EnemyPool>().AsSingle().WithArguments(enemiesPrefab,enemyParent,poolsSizes,poolSizeIndexes).NonLazy();
        Container.Bind<EnemyPoolEvent>().AsSingle().NonLazy();
    }

    private void BindProjectilePool()
    {
        Container.Bind<ProjectilePool>().AsSingle().WithArguments(projectilePrefab,projectileParent,projectilePoolSize).NonLazy();
        Container.Bind<ProjectilePoolEvent>().AsSingle().NonLazy();
    }
    
    private void SetPoolSizesIndexes()
    {
        poolSizeIndexes = new List<int>();
        for (int i = 0; i < poolsSizes.Count; i++)
        {
            poolSizeIndexes.Add(i);
        }        
    }
}