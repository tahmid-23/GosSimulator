using Damage;

namespace Gos
{
    public class GosDamageReceiver : BasicDamageReceiver
    {

        protected override bool OnHeal(float amount)
        {
            return true;
        }

        protected override bool OnDamage(float amount)
        {
            return true;
        }

        protected override void OnDeath()
        {
            
        }
    }
}