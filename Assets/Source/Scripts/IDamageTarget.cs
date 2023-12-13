using UnityEngine;

public interface IDamageTarget
{
    public bool Dead { get; }
    public Vector3 Position { get; }

    void TakeDamage(int value);
}