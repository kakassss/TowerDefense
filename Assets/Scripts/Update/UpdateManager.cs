using UnityEngine;
using Zenject;

public class UpdateManager : MonoBehaviour
{
    private UpdateProvider _updateProvider;

    [Inject]
    private void Construct(UpdateProvider updateProvider)
    {
        _updateProvider = updateProvider;
    }
    
    private void Update()
    {
        _updateProvider.UpdateBehavior();
    }
}