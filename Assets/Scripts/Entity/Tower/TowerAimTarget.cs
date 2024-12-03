using UnityEngine;

public class TowerAimTarget
{
    private float _rotateSpeed = 10f;
    
    public void AimTowerAimTarget(Transform towerRotation,IEnemy targetEnemy)
    {
        if (targetEnemy == null)
        {
            towerRotation.localRotation = Quaternion.Slerp(towerRotation.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * _rotateSpeed);
            return;
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(targetEnemy.Transform.position - towerRotation.position);
        towerRotation.localRotation = Quaternion.Slerp(towerRotation.localRotation, 
            targetRotation, Time.deltaTime * _rotateSpeed);
    }
    
}