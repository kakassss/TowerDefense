using UnityEngine;
using Zenject;

public class BaseProjectile : MonoBehaviour
{
    private ProjectilePoolEvent _projectilePoolEvent;

    [Inject]
    private void Construct(ProjectilePoolEvent projectilePoolEvent)
    {
        _projectilePoolEvent = projectilePoolEvent;
    }

    private void OnDisable()
    {
        _projectilePoolEvent.FireDeactivated(this);
    }
}
