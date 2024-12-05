using UnityEngine;

public class MovementUtils
{
    public void TranslateForward(Transform transform, float movementSpeed, float direction = 1)
    {
        transform.position += movementSpeed * Time.deltaTime * (-Vector3.right * direction); ;
    }
}