namespace Inventory
{
    public abstract class Weapon : Item
    {
        private readonly float _damage;

        protected Weapon(float damage)
        {
            _damage = damage;
        }

        public float GetDamage()
        {
            return _damage;
        }
    }
}