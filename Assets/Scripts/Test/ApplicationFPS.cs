using UnityEngine;

public class ApplicationFPS : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}
