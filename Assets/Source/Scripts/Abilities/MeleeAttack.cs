using System.Collections;
using UnityEngine;

public class MeleeAttack : Ability
{
    [SerializeField] private int _damage;
    [SerializeField] private AbilityMovement _movement;
    [SerializeField] private AttackAnimationListener _attackAnimationListener;
    [SerializeField] private CharacterAbilitiesAnimator _animator;
    
    private bool _finished = false;

    public override bool ApplyingFinished => _finished;

    protected override IEnumerator Applying(IDamageTarget target)
    {
        _finished = false;
        _movement.MoveToPosition(target.Position);

        yield return new WaitUntil(() => _movement.Finished);

        _animator.UseAbility(Name);
        
        yield return new WaitUntil(() => _attackAnimationListener.Attack);
        
        target.TakeDamage(_damage);
        
        yield return new WaitUntil(() => _attackAnimationListener.Finished);

        _movement.ReturnToDefaultPosition();

        yield return new WaitUntil(() => _movement.Finished);

        _attackAnimationListener.Clear();
        _finished = true;
    }
}