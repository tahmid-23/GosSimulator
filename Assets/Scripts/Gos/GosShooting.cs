using System.Collections.Generic;
using Bullet;
using Damage;
using Height;
using UnityEngine;

namespace Gos
{
    public class GosShooting : MonoBehaviour
    {

        private GameObject _bullet;

        private GosAiming _gosAiming;

        private Collider2D _collider;
        
        [SerializeField]
        private float bulletSpeed = 75f;

        [SerializeField] 
        private int bulletHeight = 2;

        [SerializeField]
        private float bulletDamage = 5.0f;
    
        private void Awake()
        {
            _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
            _gosAiming = GetComponent<GosAiming>();
            _collider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (_gosAiming.IsAiming && Input.GetButtonDown("Fire1"))
            {
                Vector3 position = transform.position;
                Vector3 direction = new Vector3(Mathf.Cos(_gosAiming.Aiming.Angle), 
                    Mathf.Sin(_gosAiming.Aiming.Angle));
                
                RaycastHit2D[] raycasts = Physics2D.RaycastAll(position, 
                    transform.TransformDirection(direction));
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
                            damageReceiver.ChangeHealth(-bulletDamage);
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
                BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                bulletBehaviour.speed = bulletSpeed * direction;
                bulletBehaviour.distance = bulletDistance;
            }
        }
    }
}