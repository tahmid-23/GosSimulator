namespace Inventory
{
    public abstract class Projectile : Weapon
    {
        private readonly float _fireRate;
        
        protected Projectile(float damage, float rate) : base(damage)
        {
            _fireRate = rate;
        }

        public void Fire()
        {
            Use();
        }

        public float GetRate()
        {
            return _fireRate;
        }
        
    }
}
