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
        
        private float _bulletSpeed;
        
        private GameObject _bulletPrefab;

        public void Shoot(Vector3 position, Vector3 direction, float bulletDistance)
        {
            GameObject bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();

            bulletBehaviour.speed = _bulletSpeed * direction;
            bulletBehaviour.distance = bulletDistance;
        }

        public void HandleAttack(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
            {
                damageReceiver.ChangeHealth(-Damage);
            }
        }

        public GameObject GetBulletPrefab()
        {
            return _bulletPrefab;
        }

        public float GetBulletSpeed()
        {
            return _bulletSpeed;
        }
    }
}