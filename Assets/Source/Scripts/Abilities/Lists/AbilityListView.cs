using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityListView : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private AbilityView _viewPrefab;
    [SerializeField] private RectTransform _container;

    private void Awake()
    {
        Disable();
    }

    public void Init(IEnumerable<Ability> abilities, Action<string> selectAction)
    {
        foreach (Ability ability in abilities)
        {
            AbilityView view = Instantiate(_viewPrefab, _container);
            view.Init(ability.Name, ability.Icon, selectAction);
            ability.SetView(view);
        }
    }

    public void Enable()
    {
        _canvas.SetActive(true);
    }

    public void Disable()
    {
        _canvas.SetActive(false);
    }
}