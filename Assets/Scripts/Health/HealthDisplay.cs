using System;
using Damage;
using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class HealthDisplay : MonoBehaviour
    {

        [SerializeField]
        private GameObject healthBar;

        [SerializeField]
        private Image image;

        [SerializeField]
        private int showLength = 360;

        private IDamageReceiver _damageReceiver;

        private int _updatesSinceChange;

        private void Awake()
        {
            _damageReceiver = GetComponent<IDamageReceiver>();
            _damageReceiver.ChangeHealthHandler += OnChangeHealth;
            _updatesSinceChange = showLength;
        }

        private void Update()
        {
            if (_updatesSinceChange < showLength)
            {
                healthBar.SetActive(true);
                image.fillAmount = _damageReceiver.Health / _damageReceiver.MaxHealth;
            }
            else
            {
                healthBar.SetActive(false);
            }
            ++_updatesSinceChange;
        }

        private void OnChangeHealth(float amount)
        {
            _updatesSinceChange = 0;
        }

    }
}