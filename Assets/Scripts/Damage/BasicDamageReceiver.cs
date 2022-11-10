using System;
using UnityEngine;

namespace Damage
{
    public abstract class BasicDamageReceiver : MonoBehaviour, IDamageReceiver
    {
        
        [field : SerializeField]
        public float MaxHealth { get; protected set; }
        
        public float Health { get; private set; }

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
            
            Debug.Log("Inside Change Health");
            
            if (delta > 0)
            {
                float newHealth = Math.Min(Health + delta, MaxHealth);
                if (OnHeal(newHealth - Health))
                {
                    Health = newHealth;
                }
            }
            else if (Health + delta > 0)
            {
                if (OnDamage(-delta))
                {
                    Health += delta;
                }
            }
            else if (OnDamage(Health)) {
                Health = 0;
                OnDeath();
            }
        }

        protected abstract bool OnHeal(float amount);

        protected abstract bool OnDamage(float amount);

        protected abstract void OnDeath();

    }
}