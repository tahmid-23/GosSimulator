using System;
using UnityEngine;

namespace Damage
{
    public abstract class BasicDamageReceiver : MonoBehaviour, IDamageReceiver
    {
        
        [field : SerializeField]
        public float MaxHealth { get; protected set; }

        public float Health { get; private set; }

        public IDamageReceiver.OnChangeHealth ChangeHealthHandler { get; set; } = delegate { };

        private void Awake()
        {
            Health = MaxHealth;
        }

        public void ChangeHealth(float delta)
        {
            if (Health == 0)
            {
                return;
            }

            if (delta > 0)
            {
                float newHealth = Math.Min(Health + delta, MaxHealth);
                float newDelta = newHealth - Health;
                if (OnHeal(newDelta))
                {
                    Health = newHealth;
                }
                ChangeHealthHandler.Invoke(newDelta);
            }
            else if (Health + delta > 0)
            {
                if (OnDamage(-delta))
                {
                    Health += delta;
                    ChangeHealthHandler.Invoke(delta);
                }
            }
            else if (OnDamage(Health)) {
                Health = 0;
                OnDeath();
                ChangeHealthHandler.Invoke(-Health);
                Destroy(gameObject);
            }
        }

        protected abstract bool OnHeal(float amount);

        protected abstract bool OnDamage(float amount);

        protected abstract void OnDeath();

    }
}