using Bullet;
using Damage;
using UnityEngine;
using Damage;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Projectile", fileName = "Assets/Resources/Items/Projectile")]
    public class Projectile : Weapon
    {

        [field: SerializeField]
        public float FireRate { get; private set; }

        [field: SerializeField]
        public float BulletDistance { get; private set; }

        [SerializeField]
        private float bulletSpeed;
        
        [SerializeField]
        private GameObject bulletPrefab;

        public void Shoot(Vector3 position, Vector3 direction, float bulletDistance)
        {
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();

            bulletBehaviour.speed = bulletSpeed * direction;
            bulletBehaviour.distance = bulletDistance;
        }

        public void HandleAttack(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
            {
                damageReceiver.ChangeHealth(-Damage);
            }
        }
        
    }
}