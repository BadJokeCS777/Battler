using UnityEngine;

public class CharacterAbilitiesAnimator : MonoBehaviour
{
    private readonly int Moving = Animator.StringToHash(nameof(Moving));
        
    [SerializeField] private Animator _animator;

    public void Move()
    {
        _animator.SetBool(Moving, true);
    }

    public void Stop()
    {
        _animator.SetBool(Moving, false);
    }

    public void UseAbility(string abilityName)
    {
        _animator.SetTrigger(abilityName);
    }
}