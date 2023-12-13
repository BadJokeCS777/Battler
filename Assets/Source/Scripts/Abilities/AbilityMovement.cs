using DG.Tweening;
using UnityEngine;

public class AbilityMovement : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _range = 1.5f;
    [SerializeField, Min(0f)] private float _moveSpeed = 1.5f;
    [SerializeField, Min(0f)] private float _rotationDuration = 0.1f;
    [SerializeField] private Transform _target;
    [SerializeField] private CharacterAbilitiesAnimator _animator;

    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;
    
    public bool Finished { get; private set; } = false;

    public void MoveToPosition(Vector3 targetPosition)
    {
        Finished = false;
        _animator.Move();

        _defaultPosition = _target.position;
        _defaultRotation = _target.rotation;
        
        Vector3 direction = (targetPosition - _defaultPosition).normalized;
        Vector3 attackPosition = targetPosition - direction * _range;
        float duration = Vector3.Distance(attackPosition, _defaultPosition) / _moveSpeed;

        _target.DORotateQuaternion(Quaternion.LookRotation(direction), _rotationDuration);
        _target.DOMove(attackPosition, duration)
            .onComplete = () =>
        {
            _animator.Stop();
            Finished = true;
        };
    }

    public void ReturnToDefaultPosition()
    {
        Finished = false;
        _animator.Move();

        Vector3 direction = (_defaultPosition - _target.position).normalized;
        float duration = Vector3.Distance(_target.position, _defaultPosition) / _moveSpeed;

        DOTween.Sequence()
            .Append(_target.DORotateQuaternion(Quaternion.LookRotation(direction), _rotationDuration))
            .Join(_target.DOMove(_defaultPosition, duration).OnComplete(() => _animator.Stop()))
            .Append(_target.DORotateQuaternion(_defaultRotation, _rotationDuration))
            .onComplete += () => Finished = true;
    }
}