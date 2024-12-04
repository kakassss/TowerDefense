using UnityEngine;

public class BaseEnemyMovement
{
    public float speed;


    public void TranslateForward(Transform transform)
    {
        transform.position += speed * Time.deltaTime * -Vector3.right;
    }
    
}

public class MovementUtils
{
    public void TranslateForward(Transform transform, float movementSpeed, float direction = 1)
    {
        transform.position += movementSpeed * Time.deltaTime * (-Vector3.right * direction); ;
    }
}