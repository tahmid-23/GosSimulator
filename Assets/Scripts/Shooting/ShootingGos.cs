using System.Collections.Generic;
using Aiming;
using Damage;
using Height;
using Movement;
using UnityEngine;

namespace Shooting
{
    public class ShootingGos : MonoBehaviour
    {

        private GameObject _bullet;

        private PlayerAiming _playerAiming;
        
        [field : SerializeField]
        private int bulletSpeed = 75;

        [field: SerializeField] 
        private int bulletHeight = 1;

        [field : SerializeField]
        private float bulletDamage = 5.0f;
    
        private void Awake()
        {
            _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
            _playerAiming = GetComponent<PlayerAiming>();
        }

        private void Update()
        {
            if (_playerAiming.Aiming && Input.GetButtonDown("Fire1"))
            {
                Vector3 position = transform.position;
                Vector3 direction = new Vector3(Mathf.Cos(_playerAiming.AimingAbstract.Angle), 
                    Mathf.Sin(_playerAiming.AimingAbstract.Angle));
                
                RaycastHit2D[] raycasts = Physics2D.RaycastAll(position, 
                    transform.TransformDirection(direction));
                List<RaycastHit2D> withHeight = new List<RaycastHit2D>();
                IDictionary<RaycastHit2D, int> heights = new Dictionary<RaycastHit2D, int>();
                foreach (RaycastHit2D raycast in raycasts)
                {
                    if (raycast.collider != null &&
                        raycast.collider.gameObject.TryGetComponent(out HeightBehaviour heightBehaviour))
                    {
                        withHeight.Add(raycast);
                        heights[raycast] = heightBehaviour.Height;
                    }
                }

                withHeight.Sort((a, b) => a.distance.CompareTo(b.distance));
                
                float bulletDistance = 100;
                int maxHeight = 0;
                foreach (RaycastHit2D raycast in withHeight)
                {
                    int height = heights[raycast];
                    if (height > maxHeight)
                    {
                        maxHeight = height;
                        if (raycast.collider.gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
                        {
                            damageReceiver?.ChangeHealth(-bulletDamage);
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

                GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
                MovementBullet movementBullet = bullet.GetComponent<MovementBullet>();
                movementBullet.speed = bulletSpeed * direction;
                movementBullet.distance = bulletDistance;
            }
        }
    }
}
