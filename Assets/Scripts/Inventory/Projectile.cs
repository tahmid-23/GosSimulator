using Bullet;
using UnityEngine;

namespace Inventory
{
    public abstract class Projectile : Weapon
    {
        [field: SerializeField]
        public float FireRate { get; private set; }
        [field: SerializeField]
        public float BulletSpeed { get; private set; }
        [field: SerializeField]
        public float BulletDistance { get; private set; }
        [field: SerializeField]
        public GameObject BulletPrefab { get; private set; }

    }
}
