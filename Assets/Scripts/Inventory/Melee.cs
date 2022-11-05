using UnityEngine;

namespace Inventory
{
    public abstract class Melee : Weapon
    {

        private readonly float _attackRate;
        private readonly float _attackRange;
        
        protected Melee(float damage, float rate, float range) : base(damage)
        {
            _attackRate = rate;
            _attackRange = range;
        }

        public void Attack()
        {
            Use();
        }

        public float GetRate()
        {
            return _attackRate;
        }

        public float GetRange()
        {
            return _attackRange;
        }
    }
}
