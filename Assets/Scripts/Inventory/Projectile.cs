using Bullet;
using UnityEngine;

namespace Inventory
{
    public abstract class Projectile : Weapon
    {
        private readonly float _fireRate;
        private double _bulletSpeed;
        private double _bulletDistance;
        private GameObject _projectilePrefab = Resources.Load("Prefabs/Bullet") as GameObject;

        protected Projectile(float damage, float rate, double bulletSpeed) : base(damage)
        {
            _fireRate = rate;
            _bulletSpeed = bulletSpeed;
        }

        public void Fire()
        {
            Use();
        }

        public float GetRate()
        {
            return _fireRate;
        }


        public double GetBulletSpeed()
        {
            return _bulletSpeed;
        }

        public double GetBulletDistance()
        {
            return GetProjectilePrefab().GetComponent<BulletBehaviour>().distance;
        }

        public GameObject GetProjectilePrefab()
        {
            return _projectilePrefab;
        }
    }
}
