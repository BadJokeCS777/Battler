using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private TMP_Text _cooldownCounter;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _shining;
    [SerializeField] private GameObject _disableDark;
    
    private string _abilityName;
    private Action<string> _clickAction;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Init(string name, Sprite icon, Action<string> clickAction)
    {
        _abilityName = name;
        _icon.sprite = icon;
        _clickAction = clickAction;
    }

    public void SetSelected() => _shining.SetActive(true);

    public void SetUnselected() =>  _shining.SetActive(false);

    public void Render(int reloadMovesLeft)
    {
        if (reloadMovesLeft > 0)
        {
            _cooldownCounter.text = reloadMovesLeft.ToString();
            _disableDark.SetActive(true);
            return;
        }

        _cooldownCounter.text = "";
        _disableDark.SetActive(false);
    }
    
    private void OnClick()
    {
        _clickAction.Invoke(_abilityName);
    }
}