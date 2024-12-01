using UnityEngine;

public class BaseEnemyMovement
{
    public float speed;


    public void TranslateForward(Transform transform)
    {
        transform.position += speed * Time.deltaTime * -Vector3.right;
    }
    
}
