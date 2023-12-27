using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private int _cooldown;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    private int _movesToCooldown = 0;
    private AbilityView _view;

    public string Name => _name;
    public Sprite Icon => _icon;
    public bool Ready => _movesToCooldown <= 0;
    public abstract bool ApplyingFinished { get; }

    public void Apply(IDamageTarget target)
    {
        StartCoroutine(Applying(target));
        _movesToCooldown = _cooldown;
    }

    public void SetView(AbilityView view) => _view = view;

    public void Select() => _view?.SetSelected();

    public void Deselect() => _view?.SetUnselected();

    public void UpdateCooldown()
    {
        if (_movesToCooldown > 0)
            _movesToCooldown--;
        
        _view.Render(_movesToCooldown);
    }

    protected abstract IEnumerator Applying(IDamageTarget target);
}