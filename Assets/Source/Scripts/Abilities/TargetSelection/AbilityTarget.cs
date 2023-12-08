using System;
using UnityEngine;

public class AbilityTarget : MonoBehaviour
{
    public bool CanBeSelected => true;//DamageTarget.Dead == false;
    public IDamageTarget DamageTarget { get; private set; }

    public event Action<AbilityTarget> Clicked;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
    }

    public void Init(IDamageTarget target)
    {
        DamageTarget = target;
    }
}