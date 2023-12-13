using UnityEngine;

public class AttackAnimationListener : MonoBehaviour
{
    public bool Attack { get; private set; }
    public bool Finished { get; private set; }

    private void Awake()
    {
        Clear();
    }

    public void Clear()
    {
        Attack = false;
        Finished = false;
    }

    private void ApplyAttack()
    {
        Attack = true;
    }

    private void FinishAnimation()
    {
        Finished = true;
    }
}