using UnityEngine;

public class MockDamageTarget : MonoBehaviour, IDamageTarget
{
    [SerializeField] private AbilityTarget _target;
    
    public bool Dead { get; private set; }
    public Vector3 Position => transform.position;

    private void Start()
    {
        _target.Init(this);
    }

    public void TakeDamage(int value)
    {
        Dead = true;
    }
}