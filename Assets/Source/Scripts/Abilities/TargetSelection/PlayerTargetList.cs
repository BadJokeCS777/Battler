using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetList : ITargetList
{
    private readonly IEnumerable<AbilityTarget> _targets;

    public PlayerTargetList(IEnumerable<AbilityTarget> targets)
    {
        _targets = targets;
        Target = null;
    }

    public IDamageTarget Target { get; private set; }
    
    public void Select()
    {
        foreach (AbilityTarget target in _targets)
            target.Clicked += OnTargetClicked;
    }

    public void Reset()
    {
        Target = null;
    }

    private void OnTargetClicked(AbilityTarget target)
    {
        if (target.CanBeSelected == false)
            return;

        Target = target.DamageTarget;
        Debug.Log("Target Selected " + target.name);

        foreach (AbilityTarget abilityTarget in _targets)
            abilityTarget.Clicked -= OnTargetClicked;
    }
}