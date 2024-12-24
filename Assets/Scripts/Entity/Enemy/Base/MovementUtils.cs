using UnityEngine;

public class MovementUtils
{
    public void TranslateForward(Transform transform, float movementSpeed, float direction = 1)
    {
        transform.position += -Vector3.right * (movementSpeed * Time.deltaTime * direction); ;
    }
}