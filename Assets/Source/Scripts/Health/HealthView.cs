using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    internal class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _view;
        
        private Health _health;

        private void OnEnable()
        {
            _health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= OnHealthChanged;
        }

        internal void Init(Health health)
        {
            _health = health;
            _view.maxValue = health.MaxValue;
        }
        
        private void OnHealthChanged()
        {
            _view.value = _health.Value;
        }
    }
}
