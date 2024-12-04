using UnityEngine;

public class QuaternionUtils
{
    public void AimToTarget(Transform transform,Transform target,float rotateSpeed)
    {
        if (target == null)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotateSpeed);
            return;
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, 
            targetRotation, Time.deltaTime * rotateSpeed);
    }
}