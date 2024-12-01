using UnityEngine;
using Cysharp.Threading.Tasks;

public class UniTaskTesting : MonoBehaviour
{
    
    private async void Wassap()
    {

        await UniTask.Delay(1000);

    }
}
