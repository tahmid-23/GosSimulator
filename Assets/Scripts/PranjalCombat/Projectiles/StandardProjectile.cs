using UnityEngine;

namespace PranjalCombat.Projectiles
{
    public class StandardProjectile : Projectile
    {
        public StandardProjectile() : base()
        {
            
        }

        public override void Shoot(Vector3 position, Vector3 direction, float bulletDistance)
        {
            GameObject bullet = Instantiate(super._bulletPrefab, position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();

            bulletBehaviour.speed = bulletSpeed * direction;
            bulletBehaviour.distance = bulletDistance;
        }
    }
}