using UnityEngine;

[CreateAssetMenu(menuName = "EnemySO/EnemyGameObject",fileName = "EnemyGameObject")]
public class EnemyGameObjectSO : ScriptableObject
{
    [Header("Prefabs")] 
    public GameObject Prefab;
}