using System.Collections.Generic;
using Bullet;
using Damage;
using Gos;
using Height;
using Inventory;
using UnityEngine;

namespace Combat
{
    public class ShootingCombat : MonoBehaviour
    {
        private GameObject _bullet;

        private GosAiming _gosAiming;

        private Collider2D _collider;

        private PlayerInventory _playerInventory;
    
        private float _bulletSpeed;

        private float _bulletDamage;

        [SerializeField] 
        private int bulletHeight;

        private void Awake()
        {
            _playerInventory = GetComponent<PlayerInventory>();
            _gosAiming = GetComponent<GosAiming>();
            _collider = GetComponent<BoxCollider2D>();
        }

        public void ShootProjectile()
        {
            if (!_playerInventory.TryGetEquippedItem(out Projectile projectile))
            {
                return;
            }

            Vector2 position = transform.position;
            Vector3 direction = new Vector3(Mathf.Cos(_gosAiming.Aiming.Angle), Mathf.Sin(_gosAiming.Aiming.Angle));
                
            RaycastHit2D[] raycasts = Physics2D.RaycastAll(position,transform.TransformDirection(direction));
            List<RaycastHit2D> withHeight = new List<RaycastHit2D>();
            IDictionary<RaycastHit2D, int> heights = new Dictionary<RaycastHit2D, int>();
            foreach (RaycastHit2D raycast in raycasts)
            {
                if (raycast.collider != null && raycast.collider != _collider &&
                    raycast.collider.gameObject.TryGetComponent(out HeightBehaviour heightBehaviour))
                {
                    int height = heightBehaviour.Height;
                    if (height <= bulletHeight)
                    {
                        withHeight.Add(raycast);
                        heights[raycast] = height;
                    }
                }
            }

            withHeight.Sort((a, b) => a.distance.CompareTo(b.distance));

            float bulletDistance = projectile.BulletDistance;
            int maxHeight = 0;
            foreach (RaycastHit2D raycast in withHeight)
            {
                int height = heights[raycast];
                if (height > maxHeight)
                {
                    maxHeight = height;
                    if (raycast.collider.gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
                    {
                        damageReceiver.ChangeHealth(_bulletDamage);
                        bulletDistance = raycast.distance;
                        break;
                    }
                }
                if (height >= bulletHeight)
                {
                    bulletDistance = raycast.distance;
                    break;
                }
            }
            
            InstantiateBullet(projectile, direction, bulletDistance);
        }

        private void InstantiateBullet(Projectile projectile, Vector3 direction, float bulletDistance)
        {
            GameObject bullet = Instantiate(projectile.BulletPrefab, transform.position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();

            bulletBehaviour.speed = projectile.BulletSpeed * direction;
            bulletBehaviour.distance = bulletDistance;
        }
    }
}
