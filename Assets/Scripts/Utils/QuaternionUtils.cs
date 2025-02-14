using System.Collections.Generic;
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


    public Vector3 SetRotation(Transform transform, List<Vector3> targetPositions)
    {
        var targetRotation = (targetPositions[0] - transform.position);

        if (targetPositions.Count == 0) return targetRotation;
        
        
        Vector3 distance = transform.position - targetPositions[0];
        for (int i = 0; i < targetPositions.Count; i++)
        {
            if (distance.magnitude < (transform.position - targetPositions[i]).magnitude)
            {
                targetRotation = (targetPositions[i] - transform.position);
            }
        }

        return targetRotation;
    }
}