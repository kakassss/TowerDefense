using UnityEngine;

public class BaseEnemyMovement
{
    public float speed;


    public void TranslateForward(Transform transform)
    {
        transform.Translate(speed * Time.deltaTime * -Vector3.right);
    }
    
}
