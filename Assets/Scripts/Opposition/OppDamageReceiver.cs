using Damage;
using Shooting;
using Unity.VisualScripting;
using UnityEngine;

namespace Opposition
{
    public class OppDamageReceiver : BasicDamageReceiver
    {
        
        protected override bool OnHeal(float amount)
        {
            return true;
        }

        protected override bool OnDamage(float amount)
        {
            Debug.Log($"Opp: -{amount}");
            HitAnimation hitAnimation = gameObject.GetOrAddComponent<HitAnimation>();
            hitAnimation.duration = 100;
            
            return true;
        }

        protected override void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}