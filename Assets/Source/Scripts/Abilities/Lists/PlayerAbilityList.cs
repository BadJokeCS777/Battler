using System.Linq;

public class PlayerAbilityList : IAbilityList
{
    private readonly Ability[] _abilities;
    private readonly AbilityListView _view;

    private Ability _selected;

    public PlayerAbilityList(Ability[] abilities, AbilityListView view)
    {
        _abilities = abilities;
        _view = view;
    }

    public bool AbilityFinished => _selected.ApplyingFinished;

    public void Init()
    {
        _view.Init(_abilities, SelectByName);
    }
        
    public void StartSelecting()
    {
        SelectFirst();
        
        _view.Enable();
    }

    public void ApplySelectedTo(IDamageTarget damageTarget)
    {
        _view.Disable();
        _selected.Apply(damageTarget);
    }

    private void SelectByName(string name)
    {
        Ability selected = _abilities.First(a => name.Equals(a.Name)); 
            
        Select(selected);
    }

    private void SelectFirst()
    {
        Select(_abilities[0]);
    }
        
    private void Select(Ability selected)
    {
        _selected = selected;
        _selected.Select();

        foreach (Ability ability in _abilities)
            if (ability != _selected)
                ability.Deselect();
    }
}