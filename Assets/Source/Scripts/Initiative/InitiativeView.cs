using UnityEngine;
using UnityEngine.UI;

public class InitiativeView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public void Render(float value)
    {
        _slider.value = value;
    }
}