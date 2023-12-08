using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AiTargetList : ITargetList
{
    private readonly IEnumerable<AbilityTarget> _targets;

    internal AiTargetList(IEnumerable<AbilityTarget> targets)
    {
        _targets = targets;
    }

    public IDamageTarget Target { get; private set; }

    public void Select()
    {
        AbilityTarget[] targets = _targets.Where(t => t.CanBeSelected).ToArray();

        Target = targets[Random.Range(0, targets.Length)].DamageTarget;
    }

    public void ApplySelecting()
    {
        Target = null;
    }
}