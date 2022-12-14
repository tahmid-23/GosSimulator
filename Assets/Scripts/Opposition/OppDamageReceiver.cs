using AI;
using Damage;
using Shooting;
using Unity.VisualScripting;
using UnityEngine;

namespace Opposition
{
    public class OppDamageReceiver : BasicDamageReceiver
    {

        private HitAnimation _hitAnimation;
        
        protected override bool OnHeal(float amount)
        {
            return true;
        }

        protected override bool OnDamage(float amount)
        {
            if (_hitAnimation == null)
            {
                _hitAnimation = gameObject.AddComponent<HitAnimation>();
            }
            _hitAnimation.duration = 100;
            
            return true;
        }

        protected override void OnDeath()
        {
            if (TryGetComponent(out CleanUpSpillGoal spillGoal))
            {
                CleanUpSpillGoal.alive = false;
            }
            Destroy(gameObject);
        }
    }
}