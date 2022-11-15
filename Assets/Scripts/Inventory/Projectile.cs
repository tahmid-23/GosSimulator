using Bullet;
using UnityEngine;

namespace Inventory
{
    public abstract class Projectile : Weapon
    {
        [field: SerializeField]
        public float FireRate { get; private set; }
        [field: SerializeField]
        public double BulletSpeed { get; private set; }
        [field: SerializeField]
        public double BulletDistance { get; private set; }
        [field: SerializeField]
        public GameObject ProjectilePrefab { get; private set; }

        public void Fire()
        {
            Use();
        }

        public float GetRate()
        {
            return FireRate;
        }

        public double GetBulletDistance()
        {
            return ProjectilePrefab.GetComponent<BulletBehaviour>().distance;
        }

    }
}
