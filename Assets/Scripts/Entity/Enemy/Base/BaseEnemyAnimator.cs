using UnityEngine;

public class BaseEnemyAnimator
{
    //References
    private Animator _animator;
    
    //Animations
    private static readonly int Enemy_Move001 = Animator.StringToHash("Enemy_Move001");
    private static readonly int Enemy_Attack001 = Animator.StringToHash("Enemy_Attack001");
    
    //Transition Times
    private float _attackTransitionTime;
    private float _walkTransitionTime;
    
    public void SetAnimator(Animator animator)
    {
        _attackTransitionTime = 0.2f;
        _walkTransitionTime = 0.2f;
        
        _animator = animator;
    }

    //Public Methods
    
    public void SetWalking() => _animator.CrossFade(Enemy_Move001, 0);
    public void SetAttacking() => _animator.CrossFade(Enemy_Attack001, 0);
}