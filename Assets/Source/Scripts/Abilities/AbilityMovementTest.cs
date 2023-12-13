using UnityEngine;

public class AbilityMovementTest : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private AbilityMovement _abilityMovement;

    [ContextMenu(nameof(GoToTarget))]
    private void GoToTarget()
    {
        _abilityMovement.MoveToPosition(_target.position);
    }
    
    [ContextMenu(nameof(ReturnToDefaultPosition))]
    private void ReturnToDefaultPosition()
    {
        _abilityMovement.ReturnToDefaultPosition();
    }
}