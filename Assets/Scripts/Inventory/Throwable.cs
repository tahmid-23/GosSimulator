using UnityEngine;

namespace Inventory
{
    public abstract class Throwable : Weapon
    {
        private readonly float _throwRange;
        
        protected Throwable(float damage, float range) : base(damage)
        {
            _throwRange = range;
        }

        public void Throw()
        {
            Use();
        }

        public float GetThrowRange()
        {
            return _throwRange;
        }
    }
}
