using System.Collections;
using System.Collections.Generic;
using Bullet;
using Damage;
using Gos;
using Height;
using Inventory;
using Opposition;
using UnityEngine;

public class ShootingCombat : MonoBehaviour
{
    private GameObject _bullet;

    private GosAiming _gosAiming;

    private Collider2D _collider;

    private Inventory.Inventory _inventory;
    
    private float _bulletSpeed;

    private float _bulletDamage;

    private double _bulletDistance;

    [SerializeField] 
    private int bulletHeight;

    private void Awake()
    {
        _inventory = GetComponent<Inventory.Inventory>();
        _gosAiming = GetComponent<GosAiming>();
        _collider = GetComponent<BoxCollider2D>();

        // Add something about bullet height but idk what
    }

    public void ActivateWeapon()
    {
        Projectile castedWeapon = (Projectile) _inventory.GetEquippedItem();
        
        _bulletSpeed = (float) castedWeapon.BulletSpeed;
        _bulletDamage = castedWeapon.Damage;
        _bullet = castedWeapon.ProjectilePrefab;
        _bulletDistance = castedWeapon.GetBulletDistance();
    }

    public void ShootProjectile()
    { 
        ActivateWeapon();
        Vector3 position = transform.position;
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
                    _bulletDistance = raycast.distance;
                    break;
                }

                // OppDamageReceiver oppDamageReceiver = raycast.transform.gameObject.GetComponent<OppDamageReceiver>();
                // // Debug.Log(oppDamageReceiver.MaxHealth);

                // if (oppDamageReceiver == null)
                // {
                //     Debug.Log("Is null");
                // }
                // if (oppDamageReceiver != null)
                // {
                //     Debug.Log("Is not null");
                //     oppDamageReceiver.ChangeHealth(_bulletDamage);
                //     _bulletDistance = raycast.distance;
                //     break;
                // }

                // if (raycast.collider.gameObject.TryGetComponent(out OppDamageReceiver oppDamageReceiver))
                // {
                //     oppDamageReceiver.ChangeHealth(_bulletDamage);
                //     Debug.Log("In");
                // }
            }
            if (height >= bulletHeight)
            {
                _bulletDistance = raycast.distance;
                break;
            }
        }
            
        // GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
        // BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        // Debug.Log(bulletSpeed);
        // bulletBehaviour.speed = bulletSpeed * direction; 
        // bulletBehaviour.distance = (float) _bulletDistance;
        InstantiateProjectile(direction);
    }

    private void InstantiateProjectile(Vector3 direction)
    {
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();

        bulletBehaviour.speed = _bulletSpeed * direction;
    }
}
